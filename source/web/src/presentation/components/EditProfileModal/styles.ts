import styled from 'styled-components'

import Button from '@components/Button'

export const Modal = styled.div`
  background-color: var(--primary);
  border-radius: 16px;

  margin-top: 2.5%;

  flex-shrink: 1;
  flex-grow: 1;
  align-items: stretch;
  flex-direction: column;

  min-width: 600px;
  min-height: 400px;

  max-width: 80vw;
  max-height: 90vw;

  height: 650px;

  overflow-x: hidden;
`

export const Header = styled.div`
  position: sticky;
  top: 0;
  align-items: stretch;
  display: flex;
  flex-direction: column;
  height: 53px;
  flex-direction: row;
  padding: 0 16px;

  backdrop-filter: blur(12px);
`

export const CloseButtonArea = styled.div`
  min-width: 36px;
  min-height: 36px;
  margin-left: calc(-8px);
  font-weight: 700;
  display: flex;
`

export const TitleArea = styled.div`
  display: flex;
  align-items: flex-start;

  > span {
    line-height: 24px;
    font-size: 20px;
    font-weight: 700;
    color: rgb(217, 217, 217);
  }
`

export const SaveButton = styled(Button)`
  align-items: flex-end;
  background-color: rgb(239, 243, 244);
  color: rgb(15, 20, 25);
`

export const Body = styled.div`
  display: flex;
  flex-direction: row;
`
