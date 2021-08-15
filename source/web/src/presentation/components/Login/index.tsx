import { useContext } from 'react'
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
} from './styles'

import Button from '../Button'

export function Login() {
  const { openSignUpModal, openSignInModal } = useContext(LoginContext)
  const httpClient = new WingsHttpClient()

  let fakeUserId = '0181add2-1775-4f46-a9f0-072852c417f4'

  const goToHome = () => {
    // return <Redirect to={{
    //   pathname: "/home"
    // }} />
    // history.push('/home')
    Router.push(`home/${fakeUserId}`)
  }

  // const signUpGitHub = async () => {
  //   let user = {
  //     username: 'djrdjrjan',
  //     email: 'guilhermedjrdjrjan@gmail.com',
  //     associateExistingAccount: false,
  //     loginProvider: 'GitHub',
  //     providerDisplayName: 'GitHub',
  //     providerKey: 'wedesrgfresg',
  //   }
  //   await httpClient.httpPost('/api/SocialAccounts/Associate', user)
  // }

  const signUpGitHub = async () => {
    const externalLoginDto: AssociateExternalLoginDto = {
      Username: 'djrdjrjan',
      Email: 'guilhermedjrdjrjan@gmail.com',
      AssociateToExistingAccount: false,
      LoginProvider: 'GitHub'
    }
    await httpClient.SignUpWithSocialAccount(externalLoginDto)
  }

  const signInGitHub = async () => {
    await httpClient.SignInWithSocialAccount('GitHub')
  }

  return (
    <Container>
      <Cover />
      <LoginArea>
        <Logo />
        <Slogan>{resource.Login.Slogan}</Slogan>
        <LoginMessage>{resource.Login.Message}</LoginMessage>
        <ButtonsArea>
          <Button outlined={false} onClick={openSignUpModal}>
            {resource.Login.SignUp}
          </Button>
          <Button
            outlined={false}
            onClick={signUpGitHub}
          >
            Cadastrar com GitHub
          </Button>
          <Button
            outlined={true}
            // onClick={openSignInModal}
            onClick={goToHome}
          >
            {resource.Login.SignIn}
          </Button>
          <Button outlined={false} onClick={signInGitHub}>
            Entrar com GitHub
          </Button>
        </ButtonsArea>
      </LoginArea>
    </Container>
  )
}
