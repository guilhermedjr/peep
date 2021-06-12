import StickyBox from 'react-sticky-box'

import { List } from '../List'
import { News } from '../News'
import { FollowSuggestion } from '../FollowSuggestion'
import {
  Container,
  SearchWrapper,
  SearchInput,
  SearchIcon,
  Body
} from './styles'

export function SideBar() {
  return (
    <Container>
      <SearchWrapper>
        <SearchInput placeholder="Buscar no Twitter" />
        <SearchIcon />
      </SearchWrapper>

      <StickyBox>
        <Body>
          <List 
            title="Acontecendo agora"
            elements={[
              <h1>Teste</h1>,
              <h1>Teste</h1>,
              <h1>Teste</h1>
            ]}
          />
          <List 
            title="Talvez você curta"
            elements={[
              <FollowSuggestion
                name="Rocketseat"
                nickname="@rocketseat"
              />,
              <FollowSuggestion
              name="Gabriel Froes"
              nickname="@GabrielFroes"
              />,
              <FollowSuggestion
              name="balta.io"
              nickname="@balta_io"
              />
            ]}
          />
          <List
            title="Acontecendo agora"
            elements={[
              <News 
                label="Assuntos do momento no Brasil"
                title="CPI da Covid"
              />,
              <News 
                label="Assuntos do momento no Brasil"
                title="Fora Bozo"
              />,
              <News 
                label="Assuntos do momento no Brasil"
                title="#VOLTALULA"
              />
            ]}
          />
        </Body>
      </StickyBox>
    </Container>
  )
}