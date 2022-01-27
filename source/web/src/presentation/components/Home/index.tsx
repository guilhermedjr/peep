import { useContext } from 'react'
import { Container, Wrapper } from '@styles/main'
import Main from '@components/Main'
import { MenuBar } from '@components/MenuBar'
import { SideBar } from '@components/SideBar'
import { PeepModal } from '@components/PeepModal'
import { EditProfileModal } from '@components/EditProfileModal'
import { PeepsContext } from '@contexts/PeepsContext'

export function Home() {
  const { isModalOpen } = useContext(PeepsContext)
  return (
    <>
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
      <PeepModal />
      <EditProfileModal isVisible={true} />
    </>
  )   
}



