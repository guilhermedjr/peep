import * as React from 'react'
import { useContext, useState, useEffect } from 'react'
import useTranslation from '../../hooks/useTranslation'
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

type PeepModalProps = {
  isVisible: boolean
}

export function PeepModal(props: PeepModalProps) {
  const { t } = useTranslation()
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
    <Container visible={false}>
      <Modal>
        <Header>Fechar</Header>
        <Body>
          <ProfileSection>
            <Avatar>
              <ProfileImage src="defaultProfileImage.png" />
            </Avatar>
          </ProfileSection>
          <PeepSection>
            <Description 
              placeholder={t("PeepModal.Placeholder")}
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