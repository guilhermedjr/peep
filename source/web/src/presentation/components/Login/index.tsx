import * as React from 'react'
import { useContext } from 'react'
import ptBR from '../../../i18n/locales/pt-br'
import { AuthContext } from '@contexts/AuthContext'

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
  const { login } = useContext(AuthContext)

  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{ptBR.Login.Slogan}</Slogan>
        <LoginMessage>{ptBR.Login.Message}</LoginMessage>
        <ButtonsArea>
          <SocialLoginButton onClick={login}>
            <SocialLoginIcon 
              src={'google.svg'} 
              title={ptBR.Login.SocialAccount.Google.SignIn} 
              alt={ptBR.Login.SocialAccount.Google.SignIn}
            />
            <p>{ptBR.Login.SocialAccount.Google.SignIn}</p>
          </SocialLoginButton>
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}
