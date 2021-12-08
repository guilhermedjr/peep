import { GoogleAuthProvider, getAuth, signInWithRedirect, getRedirectResult, UserCredential } from 'firebase/auth'
import { initializeApp } from 'firebase/app'
import { LoginDto } from '../contracts/Entity'

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

// export const getGoogleTokens = (): LoginDto => {
//   var loginDto: LoginDto
//   signInWithRedirect(auth, googleProvider)
//   getRedirectResult(auth)
//   .then(result => {
//     const credential = GoogleAuthProvider.credentialFromResult(result)
//     loginDto.Token = credential.accessToken
//     const user = result.user
//     alert(`Usuário: ${user}`)
//     auth.currentUser
//       .getIdToken()
//       .then(idToken => {
//         loginDto.IdToken = idToken
//       })
//     })
//   return loginDto
// }

export const getGoogleTokens = async(): Promise<LoginDto> => {
  alert("CARALHO")
  let loginDto: LoginDto

  signInWithRedirect(auth, googleProvider)
  let userCredential: UserCredential = await getRedirectResult(auth)
  const credential = GoogleAuthProvider.credentialFromResult(userCredential)
  loginDto.Token = credential.accessToken
  const user = userCredential.user
  alert(`Usuário: ${user}`)

  let idToken: string = await auth.currentUser.getIdToken()
  loginDto.IdToken = idToken

  return loginDto
}

