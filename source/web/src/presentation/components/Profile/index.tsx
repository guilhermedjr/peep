import { useState } from 'react'
import { ptBR as resource } from '../../resource'

import { 
  ProfileContainer, 
  Banner,
  Avatar, 
  ProfileImage,
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
import { User } from '../../../logic/contracts/Entity'

type ProfileProps = {
  user: User
}


export function Profile(props: ProfileProps) {
  const [user, setUser] = useState<User>(props.user)

  return (
    <ProfileContainer>
      <Banner>
        <Avatar>
          <ProfileImage src={
            typeof user.ProfileImagePath != 'undefined' 
              ? user.ProfileImagePath
              : 'defaultProfileImage.png'
            }/>
        </Avatar> 
      </Banner>

      <ProfileData>
        <EditButton outlined>Editar perfil</EditButton>

        <h1>{user.Name}</h1>
        <h2>@{user.Username}</h2>

        {/* <p>Cantor e compositor Ednaldo Pereira</p>
        <br />
        <p>Contribua  <a href="http://apoia.se/ednaldopereira" style={{
          color: 'var(--peep)'
        }}>http://apoia.se/ednaldopereira</a>  para receber  seu vídeo</p> */}

        <p>{user.Bio}</p>

        <ul>
          <li>
            <LocationIcon />
            {user.Location}
          </li>
          <li>
            <CakeIcon />
            {resource.User.Info.BirthDate} 1 Jan 1800
          </li>
        </ul>

        <Followage>
          <span><strong>0</strong> {resource.User.Connections.Following}</span>
          <span><strong>0</strong> {resource.User.Connections.Followers}</span>
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