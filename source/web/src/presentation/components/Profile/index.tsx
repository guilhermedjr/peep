import { useContext } from 'react'
import { UserTimelineContext } from '../../../logic/contexts/UserTimelineContext'
import { AuthContext } from '../../../logic/contexts/AuthContext'
import ptBR from '../../../i18n/locales/pt-br'
import { getDateText } from '../../utils'

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

export function Profile() {
  const { user } = useContext(UserTimelineContext)
  const { loggedUser } = useContext(AuthContext)

  return (
    <ProfileContainer>
      <Banner>
        <Avatar>
          <ProfileImage 
            data-testid="profile-profile-image"
            src={
            user.ProfileImageUrl != null
              ? user.ProfileImageUrl
              : 'defaultProfileImage.png'
            }/>
        </Avatar> 
      </Banner>

      <ProfileData>
        <EditButton 
          style={{
            display: user.Id == loggedUser?.Id
              ? 'block' : 'none'
          }} 
          outlined
        >
          Editar perfil
        </EditButton>

        <h1 data-testid="profile-name">{user.Name}</h1>
        <h2 data-testid="profile-username">@{user.Username}</h2>

        <p>{user.Bio != null ? user.Bio : ''}</p>

        <ul>
          <li>
            <LocationIcon />
            {user.Location != null ? user.Location : ''}
          </li>
          <li>
            <CakeIcon />
            {ptBR.User.Info.BirthDate} {user.BirthDate != undefined ? getDateText(user.BirthDate) : ''}
          </li>
        </ul>

        <Followage>
          <span><strong>{user.Following != undefined ? user.Following.length : '0'}</strong> {ptBR.User.Connections.Following}</span>
          <span><strong>{user.Followers != undefined ? user.Followers.length : '0'}</strong> {ptBR.User.Connections.Followers}</span>
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