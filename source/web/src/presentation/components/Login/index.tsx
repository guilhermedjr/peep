import * as React from 'react'
import { useState, useEffect } from 'react'
import Router from 'next/router'
import { ptBR as resource } from '../../resource'
import WingsHttpClient from '../../../logic/services/WingsHttpClient'
import { getGoogleTokens } from '../../../logic/services/FirebaseAuth'
import { ApplicationUser, LoginDto, LoginProvider } from '../../../logic/contracts/Entity'

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
      var loginDto: LoginDto = await getGoogleTokens()
      var user: ApplicationUser = await httpClient.SignInWithGoogle(loginDto)
      alert(`Usuário vindo da API: ${user}`)
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
