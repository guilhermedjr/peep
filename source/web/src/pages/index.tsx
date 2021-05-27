import Head from 'next/head'
import Main from '../surface/components/Main'
import { MenuBar } from '../surface/components/MenuBar'
import { SideBar } from '../surface/components/SideBar'
import { Container, Wrapper } from '../surface/styles/main'

export default function Home() {
  return (
      <>
      <Head>
        <title>Twitter</title>
      </Head>
      <body>
        <Container>
          <Wrapper>
            <MenuBar />
            <Main />
            <SideBar />
          </Wrapper>
        </Container>
      </body>
      </>
  )
}
