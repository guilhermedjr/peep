type Peep = {
  Id: string
}

type Entities = {
  peeps: Peep[]
}

type HomeTimeline = {

}

type Store = {
  entities: Entities
  homeTimeline: HomeTimeline
}

export default Store