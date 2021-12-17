import styled from 'styled-components'

export const Container = styled.div`
  z-index: 1000;
  position: fixed;
  top: 50px;

  min-height: 100px;
  max-height: calc(80vh - 53px);

  width: min(399px, 100%);

  border-radius: 8px;

  box-shadow: 
    rgb(255 255 255 / 20%) 0px 0px 15px, 
    rgb(255 255 255 / 15%) 0px 0px 3px 1px;

  background-color: var(--primary);

  overflow-y: scroll;
  overflow-x: hidden;
  overscroll-behavior: contain;

  display: flex;
  flex-direction: column;
`

export const MessageArea = styled.div`
  padding: 12px;
  padding-top: 20px;
  font-size: 15px;
  font-family: 'Segoe UI', -apple-system, Roboto, Helvetica, Arial, sans-serif;
  text-align: center;
  line-height: 20px;
  white-space: pre-wrap;
  overflow-wrap: break-word;

  > span {
    color: rgb(110, 118, 125);
  }
`

export const ResultBox = styled.div`
  display: flex;
  flex-direction: row;

  align-items: stretch;

  padding: 12px 16px;

  cursor: pointer;

  transition-property: background-color, box-shadow;
  transition-duration: 0.2s;

  &:hover {
    background-color: rgba(91, 112, 131, 0.2);
  }
`

export const ImageSection = styled.div`
  margin-right: 12px;
  flex-basis: 48px;
  justify-content: flex-start;
`

export const ImageContainer = styled.div`
  height: 48px;
  width: 100%;
  display: block;
  border-radius: 40px;
`

export const Image = styled.img`
  width: 100%;
  height: 100%;
  border-radius: 40px;
`

export const InfoSection = styled.div`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
`

export const DiscriminationInfo = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: flex-start;
  flex-shrink: 1;

  max-width: 100%;
`

export const AdditionalInfo = styled.div`
  align-items: flex-start;
  padding-left: 2px;
  font-size: 14.5px;
  line-height: 20px;
  overflow: hidden;
 
  > span {
    color: rgb(110, 118, 125);
    overflow: hidden;
    //overflow-wrap: break-word;
    text-overflow: ellipsis;
  }

`