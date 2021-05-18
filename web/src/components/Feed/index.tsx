import { Tweet } from '../Tweet'

import { Container, Tab, Tweets } from './styles'

export function Feed() {
  return (
    <Container>
      <Tab>Tweets</Tab>
      {/* <Tab>Tweets e respostas</Tab>
      <Tab>Curtidas</Tab> */}

       <Tweets>
        {/* <Tweet />
        <Tweet />
        <Tweet />
        <Tweet />
        <Tweet /> */}
      </Tweets> 
    </Container>
  )   
}