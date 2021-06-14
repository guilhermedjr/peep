import Head from 'next/head'
import { useContext } from 'react'
import Main from '../presentation/components/Main'
import { MenuBar } from '../presentation/components/MenuBar'
import { SideBar } from '../presentation/components/SideBar'
import { PeepModal } from '../presentation/components/PeepModal'
import { Container, Wrapper } from '../presentation/styles/main'
import { PeepsContext } from '../logic/contexts/PeepsContext'

export default function Home() {
  const { isModalOpen } = useContext(PeepsContext)
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
            <PeepModal isVisible={isModalOpen} />
          </Wrapper>
        </Container>
      </body>
      </>
  )
}
