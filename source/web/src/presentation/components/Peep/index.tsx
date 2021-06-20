import * as React from 'react'
import { useState, useEffect, useLayoutEffect } from 'react'
import { Redirect } from 'react-router-dom'
import { PeepHasContent } from '../../contracts/Peep'
import { getMonthText, fullTimeToSeconds } from '../../utils'
import { PeepProps } from '../../contracts/components'

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


export function Peep(props: PeepProps) {
  const [showOptions, setShowOptions] = useState<boolean>(false)

  const [viewportWidth, viewportHeight] = useWindowSize();

  // melhorar isto
  const formatDateTime = (date: string, time: string): string => {
    const now = new Date()

    date = date.replace("/", "").replace("-", "").replace("/", "").replace("-", "")

    let day = date.substr(0, 2),
        month = Number(date.substr(2, 2)),
        year = date.substr(6, 2)

    time = time.replace(":", "").replace(":", "")

    let hours = time.substr(0, 2),
        minutes = time.substr(2, 2),
        seconds = time.substr(4, 2)

    let dayNow: string = String(now.getDate())
    let monthNow: string = String(now.getMonth())
    let yearNow: string = String(now.getFullYear()).substr(2, 2)

    let hoursNow: string = String(now.getHours())
    let minutesNow: string = String(now.getMinutes())
    let secondsNow: string = String(now.getSeconds())

    if (year != yearNow)
      return `${day} ${getMonthText(month)} ${year}`

    if (String(month) == monthNow) {
      let daysSincePost = Number(dayNow) - Number(day)

      if (daysSincePost < 7) {
        if (day == dayNow) {
          if (hours == hoursNow || Number(hours) == Number(hoursNow) - 1) {
            let secondsSincePast = fullTimeToSeconds(time)

            if (secondsSincePast < 60) 
              return `${secondsSincePast}s`
            if (secondsSincePast < 3600)
              return `${Math.round(secondsSincePast / 60)}min`
            return '1h'
          } else {
            return `${Number(hoursNow) - Number(hours)}h`
          }
        } else {
            return `${Number(dayNow) - Number(day)}d`
        } 
      } 
       else {
        return `${day} ${getMonthText(month)}`
      }
    }
    else {
      return `${day} ${getMonthText(month)}`
    }

  }

  const expandPeep = () => {
    return <Redirect to={'/:peepUser/status/:peepId'} />
  }

  return (
    <Container onClick={expandPeep}>
      { props.isRepost 
          ? <Retweeted>
              <RtIcon />
              Você retweetou
            </Retweeted>
          : []
      }
      
      <Body>
        <Avatar>
          <ProfileImage src={
            typeof props.userProfileImagePath != 'undefined'
              ? props.userProfileImagePath
              : 'defaultProfileImage.png'
          }/>
        </Avatar> 

        <Content>
          <Header>
            <div>
              <strong>{props.user}</strong>
              <span>@{props.username}</span>
              <Dot />
              <time>{formatDateTime(props.date, props.time)}</time>
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
            { props.hasContent.filter(c => c.type == 0)[0].isPresent 
                ? <Description>{props.description}</Description>
                : []
            }
            { props.hasContent.filter(c => c.type == 1)[0].isPresent
               ? <ImageContent src={props.imageContentPath} />
               : []
            }
          </PeepContent>

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