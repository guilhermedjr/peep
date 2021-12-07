import * as React from 'react'
import { useState, useEffect } from 'react'
import Router from 'next/router'
import { ptBR as resource } from '../../resource'
import WingsHttpClient from '../../../logic/services/WingsHttpClient'
import { LoginProvider } from '../../../logic/contracts/Entity'

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

import Button from '../Button'

export function Login() { 
  const [isNewAccount, setIsNewAccount] = useState<boolean | undefined>(undefined)
  const [loginProviders, setLoginProviders] = useState<LoginProvider[]>([])

  const httpClient = new WingsHttpClient()
  // let fakeUserId = '0181add2-1775-4f46-a9f0-072852c417f4'

  // const goToHome = () => {
  //   // return <Redirect to={{
  //   //   pathname: "/home"
  //   // }} />
  //   // history.push('/home')
  //   Router.push(`home/${fakeUserId}`)
  // }

  useEffect(() => {
    if (isNewAccount != undefined) {
      httpClient.GetSocialLoginProviders().then(
        providers => {
          setLoginProviders(providers)
        }, error => {
          alert("Não foi possível buscar os provedores de login. Tente novamente mais tarde.")
          console.log(error)
        }
      )
    }
  }, [isNewAccount])

  const signIn = (provider: LoginProvider) => {
    if (provider == 'Google') {
      httpClient.SignInWithGoogle().then(
        user => console.log(user)
      )
    }
    // else if (provider == 'Twitter')
    //   signInWithTwitter()
    // else if (provider == 'GitHub')
    //   signInWithGithub()
  }

  let socialLoginButtons: JSX.Element[] =
    loginProviders.length > 0
      ? loginProviders.map(
        provider => {
          var titleResource: string = 
            isNewAccount
              ? provider == 'Google'
                  ? resource.Login.SocialAccount.Google.SignUp
                  : provider == 'Twitter'
                    ? resource.Login.SocialAccount.Twitter.SignUp
                    : resource.Login.SocialAccount.GitHub.SignUp
              : provider == 'Google'
                  ? resource.Login.SocialAccount.Google.SignIn
                  : provider == 'Twitter'
                    ? resource.Login.SocialAccount.Twitter.SignIn
                    : resource.Login.SocialAccount.GitHub.SignIn
          return (
            <SocialLoginButton onClick={() => signIn(provider)}>
              <SocialLoginIcon src={`${provider}.svg`} title={titleResource} alt={titleResource} />
              <p>{titleResource}</p>
            </SocialLoginButton>
          )
        }
      )
      : []
      

  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{resource.Login.Slogan}</Slogan>
        <LoginMessage>{resource.Login.Message}</LoginMessage>
        <ButtonsArea>
          { isNewAccount == undefined
              ? <>
                <Button outlined={true} onClick={() => setIsNewAccount(false)}>
                  {resource.Login.SignIn}
                </Button>
                </>
              : socialLoginButtons
          }
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}
