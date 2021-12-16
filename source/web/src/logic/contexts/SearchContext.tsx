import { createContext, useContext, useState, useEffect, ReactNode } from 'react'
import { HttpStatusCode } from '../contracts/HttpClient'
import ParrotHttpClient from '../services/ParrotHttpClient'
import { User } from '../contracts/Entity'

type SearchContextData = {
  search: (s: string) => Promise<any>
  results: User[]
}

type SearchProviderProps = {
  children: ReactNode
}

export const SearchContext = createContext({} as SearchContextData)

export default function SearchProvider({children}: SearchProviderProps) {
  const httpClient = new ParrotHttpClient()
  const [results, setResults] = useState<User[]>([
    {
       Id: '1',
       Name: "Guilherme Djrdjrjan",
       Username: "guilhermedjrdjrjan",
       Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '2',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '3',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '4',
      Name: "Caqui",
      Username: "guilhermedjrdjrjan",
      Bio: "drgtkrkeykrtykrtkykrtyktykuktyukykukyuikdgkrtghkrtykrtkyrtkyktyktykuktykuktykutykuktykutykukty8kikyuktykuk6rt7kyuk6tyuktykukyutktyukktyukiykuikyukikyuikyukikuykuikyukiykuikyuk"
    },
    {
      Id: '5',
      Name: "fjretgjretrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt",
      Username: "erteryrtytyutytyututyutytyuyuytyyyyyyyyyyte5yryrtytyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '6',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '7',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '8',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '9',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
    {
      Id: '10',
      Name: "Guilherme Djrdjrjan",
      Username: "guilhermedjrdjrjan",
      Bio: "Programadorzinho Full-StackOverflow"
    },
  ])

  async function search(s: string): Promise<any> {
    const response = await httpClient.httpGet(`api/Search?s=${s}`)
    setResults(response.data as User[])
  }

  return (
    <SearchContext.Provider
      value={{
        search,
        results
      }}
    >
      { children }
    </SearchContext.Provider>
  )
}
