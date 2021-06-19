import styled from 'styled-components'
import { Twitter } from '../../styles/icons'

export const Container = styled.div`
  display: flex;
`

export const Cover = styled.div`
  width: 45%;
  height: 720px;
  background-image: url('twitter-cover.jpg');
  background-repeat: space;

  @media screen and (max-width: 585px) {
    display: none;
  }
`

export const LoginArea = styled.div`
  width: 55%;
  height: 100%;

  display: flex;
  flex-direction: column;
  justify-content: space-between;

  padding: 60px 32px 60px 32px;

  @media screen and (max-width: 585px) {
    width: 100%;
  }
`

export const Logo = styled(Twitter)`
  width: 60px;
  height: 60px;

  > path {
    fill: var(--white);
  }
`

export const Slogan = styled.h1`
  font-size: 40px;
  letter-spacing: -0.8px;
  font-weight: 700;

  margin-top: 60px;

`

export const LoginMessage = styled.h2`
  font-size: 30px;
  font-weight: 700;

  margin-top: 40px;
`

export const ButtonsArea = styled.div`
  display: flex;
  flex-direction: column;

  margin-top: 30px;
  margin-left: 1px;

  > button {
    width: 60%;
  }
  
  > button:nth-child(2) {
    margin-top: 20px;
  }

  @media screen and (max-width: 500px) {
    > button {
      width: 100%;
    }
  }
`