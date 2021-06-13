import * as React from 'react'
import { useState, useEffect, useContext } from 'react'
import { PeepsContext } from '../../../logic/contexts/PeepsContext'

import {
  Container,
  ProfileSection,
  PeepSection,
  Description,
  // SelectedReplyRestriction,
  // ReplyRestrictionOptions,
  EveryoneIcon,
  FollowedIcon,
  MentionedIcon,
  ContentOptions,
  MediaIcon,
  GifIcon,
  PollIcon,
  EmojiIcon,
  ScheduleIcon,
  AddPeepButton
} from './styles'

type PeepModalProps = {
  isVisible: boolean
}

export function PeepModal(props: PeepModalProps) {
  const { addPeep, editPeep, isModalOpen } = useContext(PeepsContext)
  
  return (
    <Container style={{
      display: props.isVisible 
        ? 'flex' : 'none'
    }}>
      <ProfileSection />
      <PeepSection>
        <div>
          <Description />
          {/* <SelectedReplyRestriction>
            {/* <ReplyRestrictionOptions>
            <ReplyRestrictionOptions /> */}
          {/* </SelectedReplyRestriction>  */}
        </div>
        <div>
          <ContentOptions>
            <MediaIcon />
            <GifIcon />
            <PollIcon />
            <EmojiIcon />
            <ScheduleIcon />
          </ContentOptions>
          <AddPeepButton />
        </div>
      </PeepSection>
    </Container>
  )
}