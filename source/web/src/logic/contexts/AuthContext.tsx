import { createContext, useContext, useState, ReactNode } from 'react'
import { useCookies } from 'react-cookie'
import Router from 'next/router'
import { GoogleAuthProvider, getAuth, signInWithPopup } from 'firebase/auth'
import { initializeApp } from 'firebase/app'
import WingsHttpClient from '../services/WingsHttpClient'
import { UserTimelineContext } from './UserTimelineContext'
import { User } from '../contracts/Entity'

type AuthContextData = {
  login: () => Promise<void>
  loggedUser: User,
  isAuthenticated: boolean
}

type AuthProviderProps = {
  children: ReactNode
}

const firebaseConfig = {
  apiKey: "AIzaSyD_54T8GXnq89MN6Fp3v698-o4tzUuC024",
  authDomain: "peep-61ac0.firebaseapp.com",
  projectId: "peep-61ac0",
  storageBucket: "peep-61ac0.appspot.com",
  messagingSenderId: "148668682344",
  appId: "1:148668682344:web:883637607417922f00ebdd",
  measurementId: "G-E6G97JNRZF"
}

const app = initializeApp(firebaseConfig)
const auth = getAuth(app)

var googleProvider = new GoogleAuthProvider()
googleProvider.addScope("https://www.googleapis.com/auth/userinfo.profile")

export const AuthContext = createContext({} as AuthContextData)

export default function AuthProvider({children}: AuthProviderProps) {
  const httpClient = new WingsHttpClient()
  const [cookies, setCookie] = useCookies(['peep-token', 'user-id'])
  const [loggedUser, setLoggedUser] = useState<User>({} as User)
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false)
  const { getUser, user: peepUser } = useContext(UserTimelineContext)
  
  const goToHome = (userId: string) => {
    getUser(userId).then(
      promiseResolved => { 
        setIsAuthenticated(true)
        Router.push('home') 
        setLoggedUser(peepUser)
      }
    )
  }

  async function login(): Promise<void> {
    signInWithPopup(auth, googleProvider).then(
      result => {
        const credential = GoogleAuthProvider.credentialFromResult(result)
        const token = credential.accessToken
        auth.currentUser.getIdToken().then(
          idToken => {  
            setCookie('peep-token', idToken)
            httpClient.SignInWithGoogle({ Token: token, IdToken: idToken }).then(
              user => { 
                setCookie('user-id', user.Id)
                goToHome(user.Id)
              }
            )
          }
        )
      }
    )
  }

  return (
    <AuthContext.Provider
      value={{
        login,
        loggedUser,
        isAuthenticated
      }}
    >
      { children }
    </AuthContext.Provider>
  )
}