import * as React from 'react'
import { useState, useEffect, useLayoutEffect } from 'react'
import { Redirect } from 'react-router-dom'
import { Peep, User } from '../../../logic/contracts/Entity'
import { getMonthText, fullTimeToSeconds, formatDateTime } from '../../utils'

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


export function Peep(props: PeepProps) {
  const [showOptions, setShowOptions] = useState<boolean>(false)

  const [viewportWidth, viewportHeight] = useWindowSize();

  const expandPeep = () => {
    return <Redirect to={'/:peepUser/status/:peepId'} />
  }

  return (
    <Container onClick={expandPeep}>
      {/* { props.isRepost 
          ? <Retweeted>
              <RtIcon />
              Você repostou
            </Retweeted>
          : []
      } */}
      <Body>
        <Avatar>
          <ProfileImage src={
            props.user.ProfileImageUrl != null
            ? props.user.ProfileImageUrl
            : 'defaultProfileImage.png'
          } />
        </Avatar> 

        <Content>
          <Header>
            <div>
              <strong>{props.user.Name}</strong>
              <span>@{props.user.Username}</span>
              <Dot />
              <time>{formatDateTime(props.peep.PublicationDate, props.peep.PublicationTime)}</time>
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
              <span>{props.peep.Replies.length}</span>
            </Status>
            <Status>
              <RetweetIconArea>
                <RetweetIcon />
              </RetweetIconArea>
              <span>{props.peep.Rps.length + props.peep.Quotes.length}</span>
            </Status>
            <Status>
              <LikeIconArea>
                <LikeIcon />
              </LikeIconArea>
              <span>{props.peep.Likes.length}</span>
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