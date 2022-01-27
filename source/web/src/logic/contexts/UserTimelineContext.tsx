import { createContext, useState, ReactNode } from 'react'
import ParrotHttpClient from '@services/ParrotHttpClient'
import { User } from '@contracts/Entity'

type UserTimelineContextData = {
  getUser: (id: string) => Promise<void>
  user: User
}

type UserTimelineProviderProps = {
  children: ReactNode
}

export const UserTimelineContext = createContext({} as UserTimelineContextData)

export default function UserTimelineProvider({children}: UserTimelineProviderProps) {
  const httpClient = new ParrotHttpClient()
  const [user, setUser] = useState<User>({} as User)

  async function getUser(id: string): Promise<void> {
    const response = await httpClient.httpGet(`api/Users/${id}`)
    setUser(response.data as User)
  }

  return (
    <UserTimelineContext.Provider
      value={{
        getUser,
        user
      }}
    >
      { children }
    </UserTimelineContext.Provider>
  )
}