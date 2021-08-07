export const viewPeep = (userId: string, peepId: string) => {
  return {
    type: 'VIEW_PEEP',
  }
}

export const likePeep = (userId: string, peepId: string) => {
  return {
    type: 'LIKE_PEEP',
    payload: {
      // dados da action
    },
  }
}
