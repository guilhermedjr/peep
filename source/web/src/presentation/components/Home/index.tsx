import { useContext } from 'react'
import { Container, Wrapper } from '../../styles/main'
import Main from '../Main'
import { MenuBar } from '../MenuBar'
import { SideBar } from '../SideBar'
import { PeepModal } from '../PeepModal'
import { EditProfileModal } from '../EditProfileModal'
import { PeepsContext } from '../../../logic/contexts/PeepsContext'

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
      <PeepModal isVisible={isModalOpen} />
      <EditProfileModal isVisible={true} />
    </>
  )   
}



