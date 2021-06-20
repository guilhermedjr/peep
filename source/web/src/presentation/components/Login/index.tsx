import { useContext } from 'react'
import Router from 'next/router'
import { ptBR as resource } from '../../resource'
import { LoginContext } from '../../contexts/LoginContext'

import {
  Container,
  Cover,
  LoginArea,
  Logo,
  Slogan,
  LoginMessage,
  ButtonsArea
} from './styles'

import Button from '../Button'

export function Login() {

  const { openSignUpModal, openSignInModal } = useContext(LoginContext)

  let fakeUserId = '0181add2-1775-4f46-a9f0-072852c417f4'

  const goToHome = () => {
    // return <Redirect to={{
    //   pathname: "/home"
    // }} />
    // history.push('/home')
    Router.push(`home/${fakeUserId}`)
  }

  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{resource.Login.Slogan}</Slogan>
        <LoginMessage>{resource.Login.Message}</LoginMessage>
        <ButtonsArea>
          <Button outlined={false} onClick={openSignUpModal}>{resource.Login.SignUp}</Button>
          <Button 
            outlined={true} 
            // onClick={openSignInModal}
            onClick={goToHome}
          >
            {resource.Login.SignIn}
          </Button>
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}