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

        <h1>user</h1>
        <h2>@user</h2>

        <p>Profile description</p>

        <ul>
          <li>
            <LocationIcon />
            Somewhere
          </li>
          <li>
            <CakeIcon />
            Born 1 Jan 1800
          </li>
        </ul>

        <Followage>
          <span><strong>0</strong> Following</span>
          <span><strong>0</strong> Followers</span>
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