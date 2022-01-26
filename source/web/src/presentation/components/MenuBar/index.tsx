import { useContext } from 'react'
import Button from '../Button'
import { AuthContext } from '../../../logic/contexts/AuthContext'
import { PeepsContext } from '../../../logic/contexts/PeepsContext'

import {
  Container, 
  Topside,
  Logo,
  MenuButton,
  HomeIcon,
  ExploreIcon,
  BellIcon,
  DmIcon,
  BookmarkIcon,
  ListIcon,
  ProfileIcon,
  MoreIcon,
  Bottomside,
  Avatar,
  ProfileData,
  OptionsIcon
} from './styles'

export function MenuBar() {
  const { loggedUser } = useContext(AuthContext)
  const { openModal } = useContext(PeepsContext)
  return (
    <Container>
      <Topside>
        <Logo />

        <MenuButton>
          <HomeIcon />
          <span>Página Inicial</span>
        </MenuButton>

        <MenuButton>
          <ExploreIcon />
          <span>Explorar</span>
        </MenuButton>

        <MenuButton>
          <BellIcon />
          <span>Notificações</span>
        </MenuButton>

        <MenuButton>
          <DmIcon />
          <span>Mensagens</span>
        </MenuButton>

        <MenuButton>
          <BookmarkIcon />
          <span>Itens salvos</span>
        </MenuButton>

        <MenuButton>
          <ListIcon />
          <span>Listas</span>
        </MenuButton>

        <MenuButton className="active">
          <ProfileIcon />
          <span>Perfil</span>
        </MenuButton>

        <MenuButton>
          <MoreIcon />
          <span>Mais</span>
        </MenuButton>

        <Button data-testid="peep-button" onClick={openModal}>
          <span>Peep</span>
        </Button>
      </Topside>

      <Bottomside>
        <Avatar />
        <ProfileData>
          <strong>{loggedUser.Name}</strong>
          <span>@{loggedUser.Username}</span>
        </ProfileData>

        <OptionsIcon />
      </Bottomside>
    </Container>
  )
}