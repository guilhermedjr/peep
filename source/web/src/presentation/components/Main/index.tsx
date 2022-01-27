import { useContext, useState, useEffect } from 'react'
import { UserTimelineContext } from '@contexts/UserTimelineContext'
import { User } from '@contracts/Entity'
//import { ExpandedPeep } from '@components/ExpandedPeep'

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

const Main = () => {
  const { user } = useContext(UserTimelineContext)

  return (
    <Container>
      <Header>
        <button>
          <BackIcon />
        </button>
        <ProfileInfo>
          <strong>{user.Name}</strong>
          <span>{user.Peeps != undefined ? user.Peeps.length : '0'} Peeps</span>
        </ProfileInfo>
      </Header>

      <Profile />
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

export default Main
// export default connect(state => ({ timeline: state }))(Main)