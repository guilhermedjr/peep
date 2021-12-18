import { createContext, useContext, useState, ReactNode } from 'react'
import { useCookies } from 'react-cookie'
import Router from 'next/router'
import { GoogleAuthProvider, getAuth, signInWithPopup } from 'firebase/auth'
import { initializeApp } from 'firebase/app'
import WingsHttpClient from '../services/WingsHttpClient'
import { UserTimelineContext } from '../../logic/contexts/UserTimelineContext'
import { User } from '../../logic/contracts/Entity'

type LoginContextData = {
  login: () => Promise<void>
  loggedUser: User
}

type LoginProviderProps = {
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

export const LoginContext = createContext({} as LoginContextData)

export default function LoginProvider({children}: LoginProviderProps) {
  const httpClient = new WingsHttpClient()
  const [cookies, setCookie] = useCookies(['peep-token', 'user-id'])
  const { getUser, user: peepUser } = useContext(UserTimelineContext)
  const [loggedUser, setLoggedUser] = useState<User>({} as User)

  const goToHome = (userId: string) => {
    Router.push('home') 
    getUser(userId)
    setLoggedUser(peepUser)
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
    <LoginContext.Provider
      value={{
        login,
        loggedUser
      }}
    >
      { children }
    </LoginContext.Provider>
  )
}