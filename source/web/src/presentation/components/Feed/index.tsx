import { useContext } from 'react'
import { UserTimelineContext } from '../../../logic/contexts/UserTimelineContext'

import { PeepComponent } from '../Peep'
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
    <Peeps>
      { peeps }
    </Peeps> 
  )   
}