import {
  Container,
  Avatar,
  Info,
  FollowButton
} from './styles'

type FollowSuggestionProps = {
  name: string
  nickname: string
}

export function FollowSuggestion(props: FollowSuggestionProps) {
  return (
    <Container>
      <div>
        <Avatar />

        <Info>
          <strong>{props.name}</strong>
          <span>{props.nickname}</span>
        </Info>
      </div>

      <FollowButton outlined>Seguir</FollowButton>
    </Container>
  )
}