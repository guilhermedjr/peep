import {
  Container, 
  Retweeted,
  RtIcon,
  Body,
  Avatar,
  Content,
  Header,
  Description,
  ImageContent,
  Icons,
  Status,
  CommentIcon,
  RetweetIcon,
  LikeIcon
} from './styles'

export function Tweet() {
  return (
    <Container>
      <Retweeted>
        <RtIcon />
        Você retweetou
      </Retweeted>

      <Body>
        <Avatar />

        <Content>
          <Header>
            <strong>User</strong>
            <span>@user</span>
            {/* <Dot /> */}
            <time>8h</time>
          </Header>

          <Description>AAAAAAAAAAAAAAAAAAA que depressão</Description>

          <ImageContent />

          <Icons>
            <Status>
              <CommentIcon />
              4
            </Status>
            <Status>
              <RetweetIcon />
              9
            </Status>
            <Status>
              <LikeIcon />
              21
            </Status>
          </Icons>
        </Content>
      </Body>
    </Container>
  )
}