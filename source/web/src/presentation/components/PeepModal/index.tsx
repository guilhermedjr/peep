import * as React from 'react'
import { useContext, useState, useEffect } from 'react'
import ptBR from '../../../i18n/locales/pt-br'
import { getCookieFromKeyName } from '../../../logic/utils'
import { PeepsContext } from '../../../logic/contexts/PeepsContext'
import { AddPeepDto } from '../../../logic/contracts/Entity'

import {
  Modal,
  Header,
  Body,
  ProfileSection,
  Avatar,
  ProfileImage,
  PeepSection,
  Description,
  ReplyRestriction,
  PeepFooter,
  ContentOptions,
  RightSide,
  SendButton
} from './styles'

import Container from '../Container'

export function PeepModal() {
  const { addPeep, isModalOpen, closeModal } = useContext(PeepsContext)
  const [textContent, setTextContent] = useState("")

  const onTextContentChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    setTextContent(e.target.value)
  }

  const sendPeep = () => {
    let peepDto: AddPeepDto = {
      UserId: getCookieFromKeyName('user-id'),
      TextContent: textContent
    }
    addPeep(peepDto).then(
      ok => {
        if (ok) {
          closeModal()
          clear()
        } else {
          alert('Houve um erro ao tentar salvar o Peep. Tente novamente')
        }
      }
    )
  }

  const clear = () => {
    setTextContent("")
  }
  
  return (
    <Container data-testid="peep-modal" visible={isModalOpen}>
      <Modal>
        <Header>Fechar</Header>
        <Body>
          <ProfileSection>
            <Avatar>
              <ProfileImage data-testid="peep-modal-profile-image" src="defaultProfileImage.png" />
            </Avatar>
          </ProfileSection>
          <PeepSection>
            <Description 
              data-testid="peep-textarea"
              placeholder={ptBR.PeepModal.Placeholder}
              value={textContent} 
              maxLength={280}
              onChange={e => onTextContentChange(e)}
            />
            <ReplyRestriction />
            <PeepFooter>
              <ContentOptions>
                {/* <MediaIcon />
                <GifIcon />
                <PollIcon />
                <EmojiIcon />
                <ScheduleIcon /> */}
              </ContentOptions>
              <RightSide>
                {/* <CharacterCounterContainer>
                  <CharacterCounter />
                </CharacterCounterContainer> */}
                {/* <ThreadedPeepButton /> */}
                <SendButton 
                  data-testid="send-peep-button"
                  disabled={textContent == ""}
                  onClick={() => sendPeep()}
                >
                  Peep
                </SendButton>
              </RightSide>
            </PeepFooter>
          </PeepSection>
        </Body>
      </Modal>
    </Container>
  )
}