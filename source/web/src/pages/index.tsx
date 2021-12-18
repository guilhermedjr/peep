import Head from 'next/head'
import ptBR from '../i18n/locales/pt-br'
import { Container } from '../presentation/styles/main'
import { Login } from '../presentation/components/Login'

export default function Index() {
  return (
    <>
      <Head>
        <title>{ptBR.PageTitles.Login}</title>
      </Head>
      <body>
        <Container>
          <Login />
        </Container>
      </body>
    </>
  )
}
