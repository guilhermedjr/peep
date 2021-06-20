import { CreateAccountDto } from '../../../logic/contracts/Entity'
import { useState, useEffect } from 'react'

import {
  Container
} from './styles'

type CreateAccountModalProps = {
  isVisible: boolean
}

export function CreateAccountModal(props: CreateAccountModalProps) {
  const [user, setUser] = useState<CreateAccountDto>()

  return (
    <Container style={{
      display: props.isVisible
        ? 'flex' : 'none'
    }}>
      <h1>Modal de criar conta</h1>
    </Container>
  )
}