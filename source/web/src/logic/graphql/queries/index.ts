import { gql } from '@apollo/client'

export const GET_USER = gql`
  query GetUser($userId: ID!) {
    user(id: $userId) {
      id
      name
      username
    }
  }
`

export const GET_USER_PEEPS = gql`
  query GetUserPeeps($userId: ID!) {
    peeps(userId: $userId) {
      id
      user
      publicationDate
      publicationTime
      textContent
      replyRestriction
      quotedPeep
    }
  }
`

export const GET_PEEP = gql`
  query GetPeep($peepId: ID!) {
    peep(id: $peepId) {
      id
      source
    }
  }
`