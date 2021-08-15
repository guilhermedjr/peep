import * as React from 'react'
import { useState } from 'react'
import Router from 'next/router'
import { ptBR as resource } from '../../resource'
import { LoginContext } from '../../contexts/LoginContext'
import WingsHttpClient from '../../../logic/services/WingsHttpClient'
import { LoginProvider, AssociateExternalLoginDto } from '../../../logic/contracts/Entity'

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

  const httpClient = new WingsHttpClient()

  // let fakeUserId = '0181add2-1775-4f46-a9f0-072852c417f4'

  // const goToHome = () => {
  //   // return <Redirect to={{
  //   //   pathname: "/home"
  //   // }} />
  //   // history.push('/home')
  //   Router.push(`home/${fakeUserId}`)
  // }

  const signUp = async(loginProvider: LoginProvider): Promise<void> => {
    const externalLoginDto: AssociateExternalLoginDto = {
      Username: 'djrdjrjan',
      Email: 'guilhermedjrdjrjan@gmail.com',
      AssociateToExistingAccount: false,
      LoginProvider: loginProvider
    }
    await httpClient.SignUpWithSocialAccount(externalLoginDto)
  }

  const signIn = async(loginProvider: LoginProvider): Promise<void> =>
    await httpClient.SignInWithSocialAccount(loginProvider)

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
                <Button outlined={false} onClick={() => setIsNewAccount(true)}>
                  {resource.Login.SignUp}
                </Button>
                <Button outlined={true} onClick={() => setIsNewAccount(false)}>
                  {resource.Login.SignIn}
                </Button>
                </>
              : <>
                <SocialLoginButton onClick={() => isNewAccount ? signUp('Google') : signIn('Google')}>
                  <SocialLoginIcon 
                    src="google.svg" 
                    title={isNewAccount ? resource.Login.SocialAccount.Google.SignUp : resource.Login.SocialAccount.Google.SignIn} 
                    alt={isNewAccount ? resource.Login.SocialAccount.Google.SignUp : resource.Login.SocialAccount.Google.SignIn} 
                  />
                  <p>{isNewAccount ? resource.Login.SocialAccount.Google.SignUp : resource.Login.SocialAccount.Google.SignIn}</p>
                </SocialLoginButton>
                <SocialLoginButton onClick={() => isNewAccount ? signUp('Twitter') : signIn('Twitter')}>
                  <SocialLoginIcon 
                    src="twitter.svg" 
                    title={isNewAccount ? resource.Login.SocialAccount.Twitter.SignUp : resource.Login.SocialAccount.Twitter.SignIn}
                    alt={isNewAccount ? resource.Login.SocialAccount.Twitter.SignUp : resource.Login.SocialAccount.Twitter.SignIn}
                  />
                  <p>{isNewAccount ? resource.Login.SocialAccount.Twitter.SignUp : resource.Login.SocialAccount.Twitter.SignIn}</p>
                </SocialLoginButton>
                <SocialLoginButton onClick={() => isNewAccount ? signUp('GitHub') : signIn('GitHub')}>
                  <SocialLoginIcon 
                    src="github.svg" 
                    title={isNewAccount ? resource.Login.SocialAccount.GitHub.SignUp : resource.Login.SocialAccount.GitHub.SignIn}
                    alt={isNewAccount ? resource.Login.SocialAccount.GitHub.SignUp : resource.Login.SocialAccount.GitHub.SignIn}
                  />
                  <p>{isNewAccount ? resource.Login.SocialAccount.GitHub.SignUp : resource.Login.SocialAccount.GitHub.SignIn}</p>
                </SocialLoginButton>
                </>
          }
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}
