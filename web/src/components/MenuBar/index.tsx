import Button from '../Button'

import {
  Container, 
  Topside,
  Logo,
  MenuButton,
  HomeIcon,
  BellIcon,
  DmIcon,
  FavoriteIcon,
  ProfileIcon,
  Bottomside,
  Avatar,
  ProfileData,
  ExitIcon
} from './styles'

export function MenuBar() {
  return (
    <Container>
      <Topside>
        <Logo />

        <MenuButton>
          <HomeIcon />
          <span>Página Inicial</span>
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
          <FavoriteIcon />
          <span>Favoritados</span>
        </MenuButton>

        <MenuButton className="active">
          <ProfileIcon />
          <span>Perfil</span>
        </MenuButton>

        <Button>
          <span>Tweetar</span>
        </Button>
      </Topside>

      <Bottomside>
        <Avatar />
        <ProfileData>
          <strong>dj</strong>
          <span>@djrdjrjan</span>
        </ProfileData>

        <ExitIcon />
      </Bottomside>
    </Container>
  )
}