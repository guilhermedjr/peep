import * as React from 'react'
import { useState, useEffect } from 'react'
import { useCookies } from 'react-cookie'
import Router from 'next/router'
import { ptBR as resource } from '../../resource'
import WingsHttpClient from '../../../logic/services/WingsHttpClient'
import { LoginProvider } from '../../../logic/contracts/Entity'
import { GoogleAuthProvider, getAuth, signInWithPopup } from 'firebase/auth'
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

googleProvider.addScope("https://www.googleapis.com/auth/userinfo.profile")

import {
  Container,
  Cover,
  LoginArea,
  Logo,
  Slogan,
  LoginMessage,
  ButtonsArea,
  SocialLoginButton,
  SocialLoginIcon
} from './styles'

export function Login() { 
  const httpClient = new WingsHttpClient()
  // let fakeUserId = '0181add2-1775-4f46-a9f0-072852c417f4'

  // const goToHome = () => {
  //   // return <Redirect to={{
  //   //   pathname: "/home"
  //   // }} />
  //   // history.push('/home')
  //   Router.push(`home/${fakeUserId}`)
  // }

 

  const signIn = async(provider: LoginProvider) => {
    if (provider == 'Google') {
      signInWithPopup(auth, googleProvider).then(
        result => {
          const credential = GoogleAuthProvider.credentialFromResult(result)
          const token = credential.accessToken
          auth.currentUser.getIdToken().then(
            idToken => {
              document.cookie = `peep_token=${idToken}`
              httpClient.SignInWithGoogle({ Token: token, IdToken: idToken }).then(
                user => { alert('BLZ') }
              )
            }
          )
        }
      )
    }
  }

  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{resource.Login.Slogan}</Slogan>
        <LoginMessage>{resource.Login.Message}</LoginMessage>
        <ButtonsArea>
          <SocialLoginButton onClick={() => signIn('Google')}>
            <SocialLoginIcon 
              src={'google.svg'} 
              title={resource.Login.SocialAccount.Google.SignIn} 
              alt={resource.Login.SocialAccount.Google.SignIn} 
            />
            <p>{resource.Login.SocialAccount.Google.SignIn}</p>
          </SocialLoginButton>
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}
