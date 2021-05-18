import { 
  ProfileContainer, 
  Banner,
  Avatar, 
  ProfileData, 
  LocationIcon, 
  CakeIcon, 
  Followage,
  EditButton, 
  ProfileTweetsContainer,
  TabsContainer,
  Tab
} from './styles'

import { Feed } from '../Feed'

export function Profile() {
  return (
    <ProfileContainer>
      <Banner>
        <Avatar />
      </Banner>

      <ProfileData>
        <EditButton outlined>Editar perfil</EditButton>

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
          <span><strong>1,501</strong> Followers</span>
        </Followage>
      </ProfileData>

      <ProfileTweetsContainer>
        <TabsContainer>
          <Tab className="active">Tweets</Tab>
          <Tab>Tweets e respostas</Tab>
          <Tab>Mídia</Tab>
          <Tab>Curtidas</Tab>
        </TabsContainer>

        <Feed />
      </ProfileTweetsContainer>

    </ProfileContainer>
  )
}