import * as React from 'react'
import { useContext, useState, useEffect } from 'react'
import useTranslation from '../../hooks/useTranslation'
import { PeepsContext } from '../../../logic/contexts/PeepsContext'

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
  // ReplyRestrictionOptions,
  EveryoneIcon,
  FollowedIcon,
  MentionedIcon,
  PeepFooter,
  ContentOptions,
  MediaIcon,
  GifIcon,
  PollIcon,
  EmojiIcon,
  ScheduleIcon,
  AddPeepButton
} from './styles'

import Container from '../Container'

type PeepModalProps = {
  isVisible: boolean
}

export function PeepModal(props: PeepModalProps) {
  const { t } = useTranslation()
  const { addPeep, editPeep, isModalOpen, closeModal } = useContext(PeepsContext)
  const [textContent, setTextContent] = useState("")

  const onTextContentChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    setTextContent(e.target.value)
  }

  const sendPeep = () => {
    alert("caralho!")
    closeModal()
    clear()
  }

  const clear = () => {
    setTextContent("")
  }
  
  return (
    <Container visible={isModalOpen}>
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
                <MediaIcon />
                <GifIcon />
                <PollIcon />
                <EmojiIcon />
                <ScheduleIcon />
              </ContentOptions>
              <AddPeepButton 
                disabled={textContent == ""}
                onClick={sendPeep}
              >
                Peep
              </AddPeepButton>
            </PeepFooter>
          </PeepSection>
        </Body>
      </Modal>
    </Container>
  )
}