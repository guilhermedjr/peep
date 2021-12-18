import { createContext, useContext, useState, useEffect, ReactNode } from 'react'
import ParrotHttpClient from '../services/ParrotHttpClient'
import { User } from '../contracts/Entity'

type SearchContextData = {
  search: (s: string) => Promise<void>
  results: User[]
  resultsVisible: boolean
  showResults: () => void
  hideResults: () => void
}

type SearchProviderProps = {
  children: ReactNode
}

export const SearchContext = createContext({} as SearchContextData)

export default function SearchProvider({children}: SearchProviderProps) {
  const httpClient = new ParrotHttpClient()
  const [results, setResults] = useState<User[]>([])
  const [resultsVisible, setResultsVisible] = useState<boolean>(false)

  const showResults = () => setResultsVisible(true)
  const hideResults = () => setResultsVisible(false)

  async function search(s: string): Promise<void> {
    const response = await httpClient.httpGet(`api/Search?s=${s}`)
    setResults(response.data as User[])
  }

  return (
    <SearchContext.Provider
      value={{
        search,
        results,
        resultsVisible,
        showResults,
        hideResults
      }}
    >
      { children }
    </SearchContext.Provider>
  )
}
