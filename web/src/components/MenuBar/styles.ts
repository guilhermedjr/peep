import styled, { css } from 'styled-components'

import { 
  Home,
  Hashtag,
  Notifications, 
  Dm, 
  Bookmarks,
  List,
  Person,
  MoreCircle,
  Twitter,
  More 
} from '../../styles/icons'

export const Container = styled.div`
  display: none;

  @media (min-width: 500px) {
    display: flex;
    flex-direction: column;
    justify-content: space-between;

    position: sticky;
    top: 0;
    left: 0;

    padding: 9px 19px 20px;
    margin-left: 0;

    max-height: 100vh;
    overflow-y: auto;
  }
`

export const Topside = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;

  @media (min-width: 1280px) {
    align-items: flex-start;
  }
`
export const Logo = styled(Twitter)`
  width: 33px;
  height: 33px;

  > path {
    fill: var(--white);
  }

  margin-bottom: 13px;
`
export const MenuButton = styled.button`
  display: flex;
  align-items: center;
  flex-shrink: 0;

  > span {
    display: none;
  }

  @media (min-width: 1280px) {
    > span {
      display: inline;
      margin-left: 19px;

      font-weight: bold;
      font-size: 19px;
    }

    padding-right: 15px;
  }

  padding: 8.25px 0;
  outline: 0;

  & + button {
    margin-top: 8px;
  }

  & + button:last-child {
    display: block;
    margin: auto;
    margin-top: 10px;

    width: 75%;
    height: 33px;

    > span {
      display: none;
    }

    @media (min-width: 1280px) {
      width: 100%;
      height: unset;

      > span {
        display: inline;
      }
    }
  }

  cursor: pointer;
  border-radius: 25px;

  &:hover {
    background: var(--twitter-dark-hover);
  }

  &:hover, &.active {
    span, svg {
      color: var(--twitter);
      fill: var(--twitter);
    }
  }
`
const iconCSS = css`
  flex-shrink: 0;

  width: 30px;
  height: 30px;
  color: var(--white);
`
export const HomeIcon = styled(Home)`
  ${iconCSS}
`
export const ExploreIcon = styled(Hashtag)`
  ${iconCSS}
`

export const BellIcon = styled(Notifications)`
  ${iconCSS}
`
export const DmIcon = styled(Dm)`
  ${iconCSS}
`
export const BookmarkIcon = styled(Bookmarks)`
  ${iconCSS}
`
export const ListIcon = styled(List)`
  ${iconCSS}
`

export const ProfileIcon = styled(Person)`
  ${iconCSS}
`
export const MoreIcon = styled(MoreCircle)`
  ${iconCSS}
`

export const Bottomside = styled.div`
  margin-top: 20px;

  width: 100%;

  display: flex;
  align-items: center;

  &:hover {
    background: var(--twitter-dark-hover);
  }
`

export const Avatar = styled.div`
  width: 39px;
  height: 39px;

  flex-shrink: 0;

  border-radius: 50%;
  background: var(--gray);
`

export const ProfileData = styled.div`
  display: none;

  @media (min-width: 1280px) {
    display: flex;
    flex-direction: column;

    margin-left: 10px;
    font-size: 14px;

    > span {
      color: var(--gray);
    }
  }
`

export const OptionsIcon = styled(More)`
  display: none;

  @media (min-width: 1280px) {
    display: inline-block;
    width: 25px;
    height: 25px;
    color: var(--white);
    margin-left: 30px;
    cursor: pointer;
  }
`