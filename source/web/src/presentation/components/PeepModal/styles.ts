import styled, {css} from 'styled-components'

import { 
  Everyone, 
  Followed, 
  Mentioned,
  Media,
  Gif,
  Poll,
  Emoji,
  Schedule } from '../../styles/icons'

import Button from '../Button'

export const Container = styled.div`
  display: flex;
  flex-direction: row;

  position: fixed;
  margin: auto;
  margin-top: 15px;

  width: 40%;
  min-height: 12rem;
  max-height: 90%;

  overflow: auto;
 
  z-index: 2;
`
export const ProfileSection = styled.div`
  width: 5%;
`
export const PeepSection = styled.div`
  width: 95%;

  display: flex;
  flex-direction: column;
  align-items: flex-start;

  > div:first-child {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    padding: 15px; 
  }
  
  > div:nth-child(2) {
    display: flex;
    flex-direction: row;
    align-items: stretch;
    justify-content: space-between;
  }
`



export const Description = styled.textarea`
 min-height: 20px;
 height: auto;
`

export const ContentOptions = styled.div`
  padding: 1rem;
`

export const AddPeepButton = styled(Button)`
  padding-top: 6px 17px;
`

const iconCSS = css`
  width: 32px;
  height: 32px;

  > svg {
    fill: var(--twitter-dark-hover);
  }
`

export const EveryoneIcon = styled(Everyone)`
  ${iconCSS}
`
export const FollowedIcon = styled(Followed)`
  ${iconCSS}
`
export const MentionedIcon = styled(Mentioned)`
  ${iconCSS}
`
export const MediaIcon = styled(Media)`
  ${iconCSS}
`
export const GifIcon = styled(Gif)`
  ${iconCSS}
`
export const PollIcon = styled(Poll)`
  ${iconCSS}
`
export const EmojiIcon = styled(Emoji)`
  ${iconCSS}
`
export const ScheduleIcon = styled(Schedule)`
  ${iconCSS}
`