import { connect } from 'react-redux'

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
  return (
    <Container>
      <Header>
        <button>
          <BackIcon />
        </button>
        <ProfileInfo>
          <strong>user</strong>
          <span>5 Tweets</span>
        </ProfileInfo>
      </Header>

      <Profile />

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