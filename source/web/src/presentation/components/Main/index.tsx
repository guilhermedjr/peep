import { connect } from 'react-redux'
import { User } from '../../../logic/contracts/Entity'
import { ExpandedPeep } from '../ExpandedPeep'

import { Profile } from '../Profile'

import { 
  Container, 
  Header, 
  BackIcon, 
  ProfileInfo, 
  BottomMenu, 
  HomeIcon, 
  SearchIcon,
  BellIcon,
  DmIcon  
} from './styles'

const Main = ({ timeline, dispatch }) => {
  let user: User = {
    Name: 'Ednaldo Pereira',
    Username: 'oednaldopereira',
    Bio: 'Cantor e compositor Ednaldo Pereira',
    Location: 'Em algum lugar, pra relaxar',
    Website: 'http://apoia.se/ednaldopereira',
  }
  const userTeste = 'Ednaldo Pereira'
  const usernameTeste = 'oednaldopereira'
  return (
    <Container>
      <Header>
        <button>
          <BackIcon />
        </button>
        <ProfileInfo>
          <strong>{user.Name}</strong>
          <span>8958 Tweets</span>
        </ProfileInfo>
      </Header>

      <Profile user={user} />
      {/* <ExpandedPeep 
        user={userTeste} username={usernameTeste} 
        hasContent={[
         {type: 0,
         isPresent: true},
         {type: 1,
           isPresent: true},
         {type: 2,
           isPresent: false},
       ]}
       isRepost={false}
       date={'11/06/2021'}
       time={'16:44:00'}
       description={'Adesivo  desculpa  montagem  Ednaldo Pereira'}
       imageContentPath={'desculpaAmigoComiSuaEsposa_EdnaldoPereira.jpg'}
       source={0}
      /> */}

      <BottomMenu>
        <HomeIcon />
        <SearchIcon />
        <BellIcon />
        <DmIcon />
      </BottomMenu>
    </Container>
  )
}


export default connect(state => ({ timeline: state }))(Main)