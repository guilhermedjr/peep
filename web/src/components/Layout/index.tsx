import Main from '../Main'
import { Container, Wrapper } from './styles'

export function Layout() {
  return (
    <Container>
      <Wrapper>
        {/* <MenuBar /> */}
        <Main />
        {/* <SideBar /> */}
      </Wrapper>
    </Container>
  )
}