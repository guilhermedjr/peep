import AxiosInstances from './config'
import { AxiosResponse } from 'axios'
import { LoginProvider, LoginDto, ApplicationUser } from '../contracts/Entity'
import { GoogleAuthProvider, getAuth, signInWithRedirect, getRedirectResult } from 'firebase/auth'
import { initializeApp } from 'firebase/app'

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

googleProvider.addScope("https://www.googleapis.com/auth/contacts.readonly")

export default class WingsHttpClient {
  private readonly baseUrl = AxiosInstances.Wings
  private readonly headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type'
  }

  constructor() {}

  public async GetSocialLoginProviders(): Promise<LoginProvider[]> {
    return this.baseUrl.get('api/Accounts/Providers').then(
      response => response.data
    )
  }

  // public async SignInWithGoogle(): Promise<ApplicationUser> {
  //   let response: AxiosResponse
  //   var loginDto: LoginDto

  //   return new Promise((resolve) => {
  //     signInWithRedirect(auth, googleProvider)
  //     getRedirectResult(auth)
  //     .then(result => {
  //       const credential = GoogleAuthProvider.credentialFromResult(result)
  //       loginDto.Token = credential.accessToken
  //       const user = result.user
  //       alert(`Usuário: ${user}`)
  //       auth.currentUser
  //         .getIdToken()
  //         .then(async idToken => {
  //           loginDto.IdToken = idToken
  //           alert(`Login dto: ${loginDto}`)
  //           try {
  //             response = await this.baseUrl.post('api/Accounts/SignIn', loginDto, {
  //               headers: {
  //                 ...this.headers,
  //                 'Authorization': `Bearer ${loginDto.Token}` 
  //               }
  //             })
  //             resolve(response.data)
  //           } catch (error) {
  //              console.log(error)
  //              resolve(error.response)
  //           }
  //         })
  //     })
  //   })
  // }
  public async SignInWithGoogle(loginDto: LoginDto): Promise<ApplicationUser> {
    alert("FILHO DA PUTA")
    let response: AxiosResponse
    alert(`Login dto: ${loginDto}`)

    try {
      response = await this.baseUrl.post('api/Accounts/SignIn', loginDto, {
        headers: {
          ...this.headers,
          'Authorization': `Bearer ${loginDto.Token}` 
        }
      })
    } catch (error) {
        console.log(error)
        response = error.response
    }
    return response.data 
  }
}
