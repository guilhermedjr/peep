import Head from 'next/head'
import Main from '../presentation/components/Main'
import { MenuBar } from '../presentation/components/MenuBar'
import { SideBar } from '../presentation/components/SideBar'
import { PeepModal } from '../presentation/components/PeepModal'
import { Container, Wrapper } from '../presentation/styles/main'

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
            <PeepModal isVisible={false}/>
          </Wrapper>
        </Container>
      </body>
      </>
  )
}
