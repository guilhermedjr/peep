import Head from 'next/head'
import { useContext } from 'react'
import { Container } from '../presentation/styles/main'
import { Login } from '../presentation/components/Login'
import { LoginContext } from '../presentation/contexts/LoginContext'
import { CreateAccountModal } from '../presentation/components/CreateAccountModal'
import { ptBR as resource } from '../presentation/resource'

export default function Index() {
  const { isSignUpModalOpen } = useContext(LoginContext)
  return (
    <>
      <Head>
        <title>{resource.PageTitles.Login}</title>
      </Head>
      <body>
        <Container>
          <Login />
          <CreateAccountModal isVisible={isSignUpModalOpen} />
        </Container>
      </body>
    </>
  )
}
