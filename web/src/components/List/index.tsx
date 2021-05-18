import {
  Container,
  Item,
  Title
} from './styles'

type ListProps = {
  title: string,
  elements: React.ReactNode[]
}

export function List(props: ListProps) {
  return (
    <Container>
      <Item>
        <Title>{props.title}</Title>
      </Item>

      {props.elements.map(
        (element, i) => (
          <Item key={i}>{element}</Item>
        )
      )}
    </Container>
  )
}