import Head from 'next/head'
import { useContext } from 'react'
import Main from '../presentation/components/Main'
import { MenuBar } from '../presentation/components/MenuBar'
import { SideBar } from '../presentation/components/SideBar'
import { PeepModal } from '../presentation/components/PeepModal'
import { EditProfileModal } from '../presentation/components/EditProfileModal'
import { Container, Wrapper } from '../presentation/styles/main'
import { PeepsContext } from '../logic/contexts/PeepsContext'

export default function Home() {
  const { isModalOpen } = useContext(PeepsContext)

  return (
    <>
    <Head>
      <title>Peep</title>
    </Head>
    <body>
      <Container style={{
        //position: isModalOpen ? 'sticky' : 'absolute'
        position: 'sticky'
      }}>
        <Wrapper>
          <MenuBar />
          <Main />
          <SideBar />
        </Wrapper>
      </Container>
      <PeepModal isVisible={isModalOpen} />
      <EditProfileModal isVisible={true} />
    </body>
    </>
  )
}