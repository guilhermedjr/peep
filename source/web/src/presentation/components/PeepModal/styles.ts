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

export const Modal = styled.div`
  background-color: var(--primary);
  border-radius: 16px;

  margin-top: 2.5%;

  flex-shrink: 1;
  flex-grow: 1;
  align-items: stretch;
  flex-direction: column;

  max-width: 48vw;
  max-height: 90vh;

  height: max-content;
 
  overflow: hidden;
`

export const Header = styled.div`
  position: sticky;
  top: 0;
  align-items: stretch;
  display: flex;
  flex-direction: column;
  height: 53px;
  font-size: 15px;
  border-bottom: 1px solid var(--outline);
`

export const Body = styled.div`
  overflow: auto;
  width: 100%;

  align-items: stretch;
  display: flex;
  flex-direction: row;

  padding-top: 4px;
  padding-bottom: 4px;

  padding-left: 16px;
  padding-right: 16px;
`

export const ProfileSection = styled.div`
  padding-top: 4px;
  margin-right: 12px;

  width: 10%;

  display: flex;
  flex-direction: column;
  flex-basis: 48px;
`

export const Avatar = styled.div`
  height: 48px;
  width: 100%;
  display: block;
  border-radius: 40px;
`

export const ProfileImage = styled.img`
  width: 100%;
  height: 100%;
  border-radius: 40px;
`

export const PeepSection = styled.div`
  padding-top: 4px;

  position: static;
  width: 90%;

  align-items: stretch;
  display: flex;
  flex-direction: column;
  justify-content: center;

  /* background: pink; */
`

export const Description = styled.textarea`
  align-items: center;
  display: inline-flex;
  flex-direction: column;
  justify-content: space-between;

  outline: 0;
  resize: none;

  padding-top: 12px;
  padding-bottom: 12px;

  flex-shrink: 1;
  flex-grow: 1;

  font-size: 20px;
  font-family: 'Segoe UI', -apple-system, Roboto, Helvetica, Arial, sans-serif;
  line-height: 24px;

  white-space: pre-wrap;
  overflow-wrap: break-word;
  overflow: auto;

  color: rgba(217, 217 ,217, 1.00);

  /* background: blue; */

  max-height: 720px;
  min-height: 120px;
  width: 100%;
  position: relative;
`

export const ReplyRestriction = styled.div`
  border-bottom: 1px solid var(--outline);
`

export const PeepFooter = styled.div`
  align-items: stretch;
  display: flex;
  flex-direction: row;
  justify-content: space-between;

  flex-wrap: wrap;

  margin-left: 2px;
  margin-right: 2px;
`

export const ContentOptions = styled.div`
  margin-top: 12px;

  align-items: center;
  display: flex;
  flex-direction: row;

`

export const AddPeepButton = styled(Button)`
  margin-top: 12px;

  min-width: 36px;
  min-height: 36px;

  padding-left: 16px;
  padding-right: 16px;

  /* opacity: 0.5; */



  /* padding-top: 6px 17px; */
`

const iconCSS = css`
  width: 24px;
  height: 24px;

  > svg {
    fill: var(--peep-dark-hover);
    color: var(--peep-dark-hover);
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