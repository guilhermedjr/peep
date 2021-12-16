import Head from 'next/head'
import useTranslation from '../presentation/hooks/useTranslation'
import { Container } from '../presentation/styles/main'
import { Login } from '../presentation/components/Login'

export default function Index() {
  const { t } = useTranslation()
  return (
    <>
      <Head>
        <title>{t("PageTitles.Login")}</title>
      </Head>
      <body>
        <Container>
          <Login />
        </Container>
      </body>
    </>
  )
}
