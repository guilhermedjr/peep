import { ptBR as resource } from '../../resource'

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
  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{resource.Login.Slogan}</Slogan>
        <LoginMessage>{resource.Login.Message}</LoginMessage>
        <ButtonsArea>
          <Button outlined={false}>{resource.Login.SignUp}</Button>
          <Button outlined={true}>{resource.Login.SignIn}</Button>
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}