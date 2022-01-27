import { useContext } from 'react'
import { UserTimelineContext } from '@contexts/UserTimelineContext'

import { PeepComponent } from '@components/Peep'
import { Peeps } from './styles'

export function Feed() {
  const { user } = useContext(UserTimelineContext)

  let peeps: JSX.Element[] = 
    user.Peeps != undefined 
      ? user.Peeps.length > 0
          ? user.Peeps.map(peep => <PeepComponent peep={peep} user={user} />)
          : []
      : []

  return (
    <Peeps data-testid="feed">
      { peeps }
    </Peeps> 
  )   
}