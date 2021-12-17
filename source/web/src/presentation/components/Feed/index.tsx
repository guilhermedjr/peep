import { useContext } from 'react'
import { UserTimelineContext } from '../../../logic/contexts/UserTimelineContext'

import { Peep } from '../Peep'
import { Peeps } from './styles'

export function Feed() {
  const { user } = useContext(UserTimelineContext)

  let peeps: JSX.Element[] = 
    user.Peeps.length > 0
      ? user.Peeps.map(peep => <Peep peep={peep} user={user} />)
      : []

  return (
    <Peeps>
      { peeps }
    </Peeps> 
  )   
}