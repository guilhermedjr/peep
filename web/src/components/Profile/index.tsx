import { 
  Container, 
  Banner,
  Avatar, 
  ProfileData, 
  LocationIcon, 
  CakeIcon, 
  Followage 
} from './styles'

export function Profile() {
  return (
    <Container>
      <Banner>
        <Avatar />
      </Banner>

      <ProfileData>
        {/* <EditButton outlined>Editar perfil</EditButton> */}

        <h1>dj</h1>
        <h2>@djrdjrjan</h2>

        <p>Profile description</p>

        <ul>
          <li>
            <LocationIcon />
            Santos, Brasil
          </li>
          <li>
            <CakeIcon />
            Born 21 July 2003
          </li>
        </ul>

        <Followage>
          <span><strong>373</strong> Following</span>
          <span><strong>1,501 Followers</strong> Followers</span>
        </Followage>
      </ProfileData>
    </Container>
  )
}