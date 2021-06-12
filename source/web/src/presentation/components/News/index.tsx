import {
  Container
} from './styles'

interface NewsProps {
  label: string;
  title: string;
}

export function News(props: NewsProps) {
  return (
    <Container>
      <span>{props.label}</span>
      <strong>{props.title}</strong>
    </Container>
  )
}