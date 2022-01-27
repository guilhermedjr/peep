import * as React from 'react'
import { useState, useLayoutEffect } from 'react'
import { Peep, User } from '@contracts/Entity'
import { formatPeepDateTime } from '@presentation/utils'

import {
  Container, 
  Retweeted,
  RtIcon,
  Body,
  Avatar,
  ProfileImage,
  Content,
  Header,
  PeepContent,
  Dot,
  OptionsButton,
  OptionsButtonMobile,
  OptionsIcon,
  OptionsIconMobile,
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

function useWindowSize() {
  const [size, setSize] = useState([0, 0])
  useLayoutEffect(() => {
    function updateSize() {
      setSize([window.innerWidth, window.innerHeight])
    }
    window.addEventListener('resize', updateSize)
    updateSize()
    return () => window.removeEventListener('resize', updateSize)
  }, [])
  return size
}

type PeepProps = {
  peep: Peep,
  user: User
}


export function PeepComponent(props: PeepProps) {
  const [showOptions, setShowOptions] = useState<boolean>(false)

  const [viewportWidth, viewportHeight] = useWindowSize();

  const expandPeep = () => {
    //return <Redirect to={'/:peepUser/status/:peepId'} />
  }

  return (
    <Container onClick={expandPeep} data-testid="peep">
      {/* { props.isRepost 
          ? <Retweeted>
              <RtIcon />
              Você repostou
            </Retweeted>
          : []
      } */}
      <Body>
        <Avatar>
          <ProfileImage 
            data-testid="peep-profile-image"
            src={
              props.user.ProfileImageUrl != null
              ? props.user.ProfileImageUrl
              : 'defaultProfileImage.png'
            } 
          />
        </Avatar> 

        <Content>
          <Header>
            <div>
              <strong>{props.user.Name}</strong>
              <span>@{props.user.Username}</span>
              <Dot />
              <time>{formatPeepDateTime(props.peep.PublicationDate, props.peep.PublicationTime)}</time>
            </div>
            <div>
              { viewportWidth >= 1280
                  ?   <OptionsButton>
                        <OptionsIcon />
                      </OptionsButton>
                  :   <OptionsButtonMobile>
                        <OptionsIconMobile />
                      </OptionsButtonMobile>
              }
             
            
              {/* <PeepOptions style={{ display: showOptions ? 'flex' : 'none'}}>
              <PeepOptions/> */}
            </div>
          </Header>

          <PeepContent>
            <Description>{props.peep.TextContent}</Description>
          </PeepContent>

          <Icons>
            <Status>
              <CommentIconArea>
                <CommentIcon />
              </CommentIconArea>
              <span>{props.peep.Replies != undefined ? props.peep.Replies.length : '0'}</span>
            </Status>
            <Status>
              <RetweetIconArea>
                <RetweetIcon />
              </RetweetIconArea>
              <span>{props.peep.Rps != undefined && props.peep.Quotes != undefined ? props.peep.Rps.length + props.peep.Quotes.length : '0'}</span>
            </Status>
            <Status>
              <LikeIconArea>
                <LikeIcon />
              </LikeIconArea>
              <span>{props.peep.Likes != undefined ? props.peep.Likes.length : '0'}</span>
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