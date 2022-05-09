import { createContext, useState, ReactNode } from 'react'
import { useQuery } from '@apollo/client'
import { GET_USER, GET_USER_PEEPS } from '@logic/graphql/queries'
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
    /*const response = await httpClient.httpGet(`api/Users/${id}`)
    setUser(response.data as User)*/
    const { loading, error, data } = useQuery(GET_USER, {
      variables: { id }
    });
    setUser(data)
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