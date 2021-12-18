import { EPeepSource } from '../../../logic/contracts/Entity'

import { useParams } from 'react-router-dom'

import {
  Container,
  Retweeted,
  RtIcon,
  Body,
  Head,
  Avatar,
  Header, 
  ProfileImage,
  Content,
  OptionsButton,
  OptionsButtonMobile,
  OptionsIcon,
  OptionsIconMobile,
  PeepContent,
  InteractionsInfo,
  Description,
  ImageContent,
  PublicationInfo,
  Dot,
  Icons,
  CommentIconArea,
  RetweetIconArea,
  LikeIconArea,
  ShareIconArea,
  CommentIcon,
  RetweetIcon,
  LikeIcon,
  ShareIcon
  
} from './styles'

/*type ExpandedPeepProps = PeepProps & {
  source: EPeepSource
}*/

/*export function ExpandedPeep(props: ExpandedPeepProps) {
  const { t } = useTranslation()
  let { peepUsername, peepId } = useParams() as { peepUsername: string, peepId: string }

  return (
    <Container>
      { props.isRepost 
          ? <Retweeted>
              <RtIcon />
              Você repostou
            </Retweeted>
          : []
      }
      
      <Body>
        <Head>
          <Avatar>
            <ProfileImage src={
              typeof props.userProfileImagePath != 'undefined'
                ? props.userProfileImagePath
                : 'defaultProfileImage.png'
            }/>
          </Avatar>

          <Header>
            <div>
              <strong>{props.user}</strong>
              <span>@{peepUsername}</span>
            </div>
            <div>
              {/* { viewportWidth >= 1280
                  ?   <OptionsButton>
                        <OptionsIcon />
                      </OptionsButton>
                  :   <OptionsButtonMobile>
                        <OptionsIconMobile />
                      </OptionsButtonMobile>
              } */
              <OptionsButton>
                <OptionsIcon />
              </OptionsButton>
            
            
              {/* <PeepOptions style={{ display: showOptions ? 'flex' : 'none'}}>
              <PeepOptions/> */}
            /*</div>
          </Header>
        </Head>
        <Content>
         
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

          <PublicationInfo>
            <time>2:00 PM</time>
            <Dot />
            <time>Jun 9, 2021</time>
            <Dot />
            <span>
              {props.source == EPeepSource.PeepWebApp
                ? 'Peep Web App' 
                : props.source == EPeepSource.PeepForAndroid
                   ? 'Peep for Android'
                   : props.source == EPeepSource.PeepForIPhone
                      ? 'Peep for IPhone'
                      : 'Peep for Alexia'
              }
            </span>
          </PublicationInfo>

          <InteractionsInfo>
            <div>
              <span>111</span>
              <span>{t("Peep.Interactions.Replies")}</span>
            </div>
            <div>
              <span>111</span>
              <span>{t("Peep.Interactions.Reposts")}</span>
            </div>
            <div>
              <span>111</span>
              <span>{t("Peep.Interactions.Quotes")}</span>
            </div>
            <div>
              <span>111</span>
              <span>{t("Peep.Interactions.Likes")}</span>
            </div>
          </InteractionsInfo>

          <Icons>
            <CommentIconArea>
              <CommentIcon />
            </CommentIconArea>
            <RetweetIconArea>
              <RetweetIcon />
            </RetweetIconArea>
            <LikeIconArea>
              <LikeIcon />
            </LikeIconArea>
            <ShareIconArea>
              <ShareIcon />
            </ShareIconArea>
          </Icons>
        </Content>
      </Body>
    </Container>
  )
}*/