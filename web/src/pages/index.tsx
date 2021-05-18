import Head from 'next/head'
import Main from '../components/Main'
import { Container, Wrapper } from '../styles/main'

export default function Home() {
  return (
      <>
      <Head>
        <title>Twitter</title>
      </Head>
      <body>
        <Container>
          <Wrapper>
            {/* <MenuBar /> */}
            <Main />
            {/* <SideBar /> */}
          </Wrapper>
        </Container>
      </body>
      </>
  )
}
