import * as React from 'react'
import { useContext } from 'react'
import { LoginContext } from '../../../logic/contexts/LoginContext'
import useTranslation from '../../hooks/useTranslation'

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
  const { login } = useContext(LoginContext)
  const { t } = useTranslation()

  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{t("Login.Slogan")}</Slogan>
        <LoginMessage>{t("Login.Message")}</LoginMessage>
        <ButtonsArea>
          <SocialLoginButton onClick={login}>
            <SocialLoginIcon 
              src={'google.svg'} 
              title={t("Login.SocialAccount.Google.SignIn")} 
              alt={t("Login.SocialAccount.Google.SignIn")} 
            />
            <p>{t("Login.SocialAccount.Google.SignIn")}</p>
          </SocialLoginButton>
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}
