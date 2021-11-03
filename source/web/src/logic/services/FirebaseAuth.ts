import { GoogleAuthProvider, TwitterAuthProvider, GithubAuthProvider, 
  getAuth, signInWithRedirect, getRedirectResult } from 'firebase/auth'
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
var twitterProvider = new TwitterAuthProvider()
var githubProvider = new GithubAuthProvider()

googleProvider.addScope("https://www.googleapis.com/auth/contacts.readonly")

export const signInWithGoogle = () => {
  signInWithRedirect(auth, googleProvider)
  getRedirectResult(auth)
  .then(result => {
    const credential = GoogleAuthProvider.credentialFromResult(result)
    const token = credential.accessToken
    const user = result.user
    auth.currentUser
      .getIdToken()
      .then(idToken => {
        // Token a ser enviado para a API
        console.log(idToken);
      }).catch(error => {
        console.log(error);
      });
  }).catch(error => {
    console.log(error);
    });
}

export const signInWithTwitter = () => {
  signInWithRedirect(auth, twitterProvider)
  getRedirectResult(auth)
  .then(result => {
    const credential = TwitterAuthProvider.credentialFromResult(result)
    const token = credential.accessToken
    const user = result.user
    auth.currentUser
      .getIdToken()
      .then(idToken => {
        // Token a ser enviado para a API
        console.log(idToken);
      }).catch(error => {
        console.log(error);
      });
  }).catch(error => {
    console.log(error);
    });
}

export const signInWithGithub = () => {
  signInWithRedirect(auth, githubProvider)
  getRedirectResult(auth)
  .then(result => {
    const credential = GithubAuthProvider.credentialFromResult(result)
    const token = credential.accessToken
    const user = result.user
    auth.currentUser
      .getIdToken()
      .then(idToken => {
        // Token a ser enviado para a API
        console.log(idToken);
      }).catch(error => {
        console.log(error);
      });
  }).catch(error => {
    console.log(error);
    });
}

