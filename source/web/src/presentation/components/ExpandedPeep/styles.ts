import styled, { css } from 'styled-components'
import { Retweet, Options, Comment, Favorite, Share } from '../../styles/icons'

export const Container = styled.article`
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
  flex-direction: column;
  margin-top: 3px;

  position: relative;

`

export const Head = styled.div`
`

export const Avatar = styled.div`
  width: 49px;
  height: 49px;
  border-radius: 50%;
  flex-shrink: 0;

  position: absolute;
  top: 0;
  left: 0;
`

export const ProfileImage = styled.img`
  width: 100%;
  height: 100%;
  border-radius: 50%;
`

export const Content = styled.div`
  display: flex;
  flex-direction: column;

  width: 100%;
  margin-top: 22px;
`

export const Header = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;

  margin-left: 60px;

  font-size: 15px;
  white-space: nowrap;

  > div:first-child {
    display: flex;
    flex-direction: column;
  }

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

export const OptionsButtonMobile = styled.div`
  width: 2rem;
  height: 2rem;
  text-align: center;
`

export const Dot = styled.div`
  background: var(--gray);
  width: 1px;
  height: 1px;

  margin-top: 10px;
`
export const PeepContent = styled.div`
  
`

export const Description = styled.p`
  font-size: 22px;
`

export const ImageContent = styled.img`
  margin-top: 12px;
  width: 100%;
  height: auto;

  background: var(--outline);
  border-radius: 14px;

  cursor: pointer;

  &:hover {
    opacity: 0.7;
  }
`

export const PublicationInfo = styled.div`
  display: flex;
  border-bottom: 1px solid var(--outline);

  margin-top: 10px;
  padding-bottom: 10px;

  > span, time {
    color: var(--gray);
  }

  > div, span, time {
    margin-left: 5px;
  }

  > time:first-child {
    margin-left: 0;
  }

`

export const InteractionsInfo = styled.div`
  display: flex;
  border-bottom: 1px solid var(--outline);

  margin-top: 10px;
  padding-bottom: 10px;

  > div > span:first-child {
    font-weight: 700;
    letter-spacing: -2px;
  }

  > div > span:nth-child(2) {
    color: var(--gray);
    margin-left: 5px;
  }

  > div {
    margin-left: 15px;
  }

  > div:first-child {
    margin-left: 0;
  }
`

export const Icons = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-wrap: nowrap;
  margin: 11px auto 0;

  width: 75%;
  max-height: 1.25rem;
  height: 100%;

  > div {
    cursor: pointer;

    &:hover {
      opacity: 0.7;
    }
  }
`

const iconCSS = css`
  width: 24px;
  height: 24px;
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
  width: 19px;
  height: 19px;

  color: var(--gray);
  fill: var(--gray);
`

export const OptionsIconMobile = OptionsIcon