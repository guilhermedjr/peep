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
          <strong>dj</strong>
          <span>24.4K Tweets</span>
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