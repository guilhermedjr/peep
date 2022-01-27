import { useContext } from 'react'
import { SearchContext } from '@contexts/SearchContext'
import { UserTimelineContext } from '@contexts/UserTimelineContext'

import { VerifiedAccountIcon } from '@components/VerifiedAccountIcon'

import {
  Container,
  MessageArea,
  ResultBox,
  ImageSection,
  ImageContainer,
  Image,
  InfoSection,
  DiscriminationInfo,
  AdditionalInfo
} from './styles'

export function SearchResults() {
  const { results, resultsVisible, hideResults, loading } = useContext(SearchContext)
  const { getUser } = useContext(UserTimelineContext)

  const onResultClick = (userId: string) => {
    getUser(userId)
    hideResults()
  }

  let resultBoxes: JSX.Element[] =
    results.length > 0
      ? results.map(
        result => {
          return (
            <ResultBox
              key={result.Id}
              //onClick={() => onResultClick(result.Id)}
            >
              <ImageSection>
                <ImageContainer>
                  <Image src={
                    result.ProfileImageUrl != null
                     ? result.ProfileImageUrl
                     : 'defaultProfileImage.png'
                  } />
                </ImageContainer>
              </ImageSection>
              <InfoSection>
                <DiscriminationInfo>
                  <div 
                    style={{
                      display: 'flex',
                      flexDirection: 'row',
                      alignItems: 'center',
                      maxWidth: '100%'
                    }}
                  >
                    <div 
                      style={{
                        fontWeight: 700,
                        fontSize: '15px',
                        whiteSpace: 'nowrap',
                        lineHeight: '20px',
                        overflowWrap: 'break-word',
                        color: 'rgba(217,217,217,1.00)',
                        overflow: 'hidden',
                        display: 'flex',
                        alignItems: 'center'
                      }}
                    >
                      <span 
                        style={{
                          whiteSpace: 'nowrap',
                          overflowWrap: 'break-word',
                          overflow: 'hidden',
                          textOverflow: 'ellipsis'
                        }}
                      >
                        {result.Name}
                      </span>
                    </div>
                    <div  
                      style={{
                        display: result.VerifiedAccount
                        ? 'inlne-flex' : 'none',
                        fontSize: '15px',
                        overflowWrap: 'break-word',
                        lineHeight: '20px',
                        whiteSpace: 'pre-wrap',
                        
                      }}
                    >
                      <VerifiedAccountIcon />
                    </div>
                  </div>

                  <div 
                    style={{
                      flexShrink: 1,
                      fontSize: '14.5px',
                      lineHeight: '20px',
                      overflowWrap: 'break-word',
                      overflow: 'hidden',
                      textOverflow: 'ellipsis',

                    }}
                  >
                    <span 
                      style={{
                        overflowWrap: 'break-word',
                        textOverflow: 'ellipsis',
                        color: 'rgb(110, 118, 125)'
                      }}
                    >
                      @{result.Username}
                    </span>
                  </div>
                </DiscriminationInfo>
                <AdditionalInfo>
                  <span>{result.Bio != null ? result.Bio : ''}</span>
                </AdditionalInfo>
              </InfoSection>
            </ResultBox>
          )
        }
      )
      : []

  return (
    <Container style={{display: resultsVisible ? 'flex' : 'none'}}>
      <MessageArea 
        style={{
          display: resultBoxes.length == 0 
            ? loading
                ? 'none' : 'block'
            : 'none'
        }}
      >
        <span>Try searching for people</span>
      </MessageArea>
      { resultBoxes }
    </Container>
  )
}