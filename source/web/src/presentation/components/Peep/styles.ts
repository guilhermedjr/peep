import styled, { css } from 'styled-components'

import { Comment, Retweet, Favorite, Share, Options } from '../../styles/icons'

export const Container = styled.div`
  display: flex;
  flex-direction: column;

  padding: 14px 16px 10px 16px;

  border-bottom: 1px solid var(--outline);

  max-width: 100%;    
`

export const Retweeted = styled.div`
  display: flex;
  align-items: center;

  padding-bottom: 0.2rem;

  font-size: 13px;
  color: var(--gray);
`

export const RtIcon = styled(Retweet)`
  width: 16px;
  height: 16px;

  margin-left: 35px;
  margin-right: 9px;

  > svg {
    fill: var(--gray);
  }
`

export const Body = styled.div`
  display: flex;
  margin-top: 3px;

  position: relative;

`

export const Avatar = styled.div`
  width: 49px;
  height: 49px;
  border-radius: 50%;
  flex-shrink: 0;
  background: var(--gray);

  position: absolute;
  top: 0;
  left: 0;
`

export const Content = styled.div`
  display: flex;
  flex-direction: column;

  width: 100%;
  margin-top: -5px;
  padding-left: 59px;
`

export const Header = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;

  font-size: 15px;
  white-space: nowrap;

  strong {
    margin-right: 5px;
  }

  span, time {
    color: var(--gray);
  }

  strong, span {
    white-space: nowrap;
    text-overflow: ellipsis;
    overflow: hidden;
  }

  > div:first-child {
    display: flex;
  }
`

export const PeepOtions = styled.div`
  display: flex;
  flex-direction: column;

  z-index: 2;
`

export const Dot = styled.div`
  background: var(--gray);
  width: 1px;
  height: 1px;
  margin: 0 5px;
  margin-top: 10px;
`

export const Description = styled.p`
  font-size: 14px;
  margin-top: 4px;
`

export const ImageContent = styled.div`
  margin-top: 12px;
  width: 100%;
  height: min(285px, max(175px, 41vw));

  background: var(--outline);
  border-radius: 14px;

  cursor: pointer;

  &:hover {
    opacity: 0.7;
  }
`

export const Icons = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-wrap: nowrap;
  margin: 11px auto 0;

  width: 70%;
  max-height: 1.25rem;
  height: 100%;



  > div {
    cursor: pointer;

    &:hover {
      opacity: 0.7;
    }
  }
`

export const Status = styled.div`
  display: flex;
  align-items: center;

  font-size: 12px;

  height: auto;

  > span {
    color: var(--gray);
  }

  > svg {
    margin-right: 5px;
  }

  /* &:first-child {
    &, > svg path {
      color: var(--gray);
    }
  } */

  /* &:nth-child(2):checked {
    color: var(--retweet);

    > svg path {
      fill: var(--retweet);
    }
  }

  &:nth-child(3):hover {
    color: var(--like);

    > svg {
      fill: var(--like);
    }
  } */
`
const iconCSS = css`
  width: 19px;
  height: 19px;
`

export const CommentIcon = styled(Comment)`
  ${iconCSS}
`

export const RetweetIcon = styled(Retweet)`
  ${iconCSS}
`

export const LikeIcon = styled(Favorite)`
  ${iconCSS}
`
export const ShareIcon = styled(Share)`
  ${iconCSS}

  color: var(--gray);
  fill: var(--gray);
`

export const OptionsButton = styled.div`
  border-radius: 20px;
  width: 2rem;
  height: 2rem;

  text-align: center;


  &:hover {
    background: var(--twitter-dark-hover);

    svg {
      color: var(--twitter);
      fill: var(--twitter);
    }
  }
`

export const CommentIconArea = styled.div`
  border-radius: 20px;
  width: 2rem;
  height: 2rem;

  text-align: center;

  &:hover {
    background: var(--twitter-dark-hover);

    svg {
      color: var(--twitter);
      fill: var(--twitter);
    }
  }
`

export const ShareIconArea = CommentIconArea

export const RetweetIconArea = styled.div`
  border-radius: 20px;
  width: 2rem;
  height: 2rem;

  text-align: center;

  &:hover {
    background: var(--retweet-light);

    svg {
      color: var(--retweet);
      fill: var(--retweet);
    }
  }
`

export const LikeIconArea = styled.div`
  border-radius: 20px;
  width: 2rem;
  height: 2rem;

  text-align: center;

  &:hover {
    background: var(--like-light);

    svg {
      color: var(--like);
      fill: var(--like);
    }
  }
`

export const OptionsIcon = styled(Options)`
  ${iconCSS}

  color: var(--gray);
  fill: var(--gray);
`
