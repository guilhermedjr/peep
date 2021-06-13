import * as React from 'react'
import { useState, useEffect } from 'react'

import {
  Container, 
  Retweeted,
  RtIcon,
  Body,
  Avatar,
  Content,
  Header,
  Dot,
  OptionsButton,
  OptionsIcon,
  // OptionsButtonDot,
  // PeepOptions,
  Description,
  ImageContent,
  Icons,
  Status,
  CommentIconArea,
  RetweetIconArea,
  LikeIconArea,
  ShareIconArea,
  CommentIcon,
  RetweetIcon,
  LikeIcon,
  ShareIcon
} from './styles'


export function Peep() {
  const [showOptions, setShowOptions] = useState<boolean>(false)
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
            <div>
              <strong>User</strong>
              <span>@user</span>
              <Dot />
              <time>8h</time>
            </div>
            <div>
              <OptionsButton>
                <OptionsIcon />
              </OptionsButton>
            
              {/* <PeepOptions style={{ display: showOptions ? 'flex' : 'none'}}>
              <PeepOptions/> */}
            </div>
          </Header>

          <Description>AAAAAAAAAAAAAAAAAAA que depressão</Description>

          <ImageContent />

          <Icons>
            <Status>
              <CommentIconArea>
                <CommentIcon />
              </CommentIconArea>
              <span>4</span>
            </Status>
            <Status>
              <RetweetIconArea>
                <RetweetIcon />
              </RetweetIconArea>
              <span>9</span>
            </Status>
            <Status>
              <LikeIconArea>
                <LikeIcon />
              </LikeIconArea>
              <span>21</span>
            </Status>
            <Status>
              <ShareIconArea>
                <ShareIcon />
              </ShareIconArea>
            </Status>
          </Icons>
        </Content>
      </Body>
    </Container>
  )
}