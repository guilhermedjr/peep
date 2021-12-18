import { createContext, useState, ReactNode } from 'react'
import useDebounce from '../../presentation/hooks/useDebounce'
import ParrotHttpClient from '../services/ParrotHttpClient'
import { User } from '../contracts/Entity'

type SearchContextData = {
  searchStr: string
  onSearchChange: (e: React.ChangeEvent<HTMLInputElement>) => void
  search: (s: string) => Promise<void>
  results: User[]
  resultsVisible: boolean
  loading: boolean
  showResults: () => void
  hideResults: () => void,
  changeLoading: (loading: boolean) => void
  clearResults: () => void
}

type SearchProviderProps = {
  children: ReactNode
}

export const SearchContext = createContext({} as SearchContextData)

export default function SearchProvider({children}: SearchProviderProps) {
  const httpClient = new ParrotHttpClient()
  const [searchStr, setSearchStr] = useState<string>("")
  const [results, setResults] = useState<User[]>([])
  const [resultsVisible, setResultsVisible] = useState<boolean>(false)
  const [loading, setLoading] = useState<boolean>(false)

  const debouncedSearch = useDebounce(nextValue => search(nextValue), 800)

  const onSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    clearResults()
    const { value: nextValue } = e.target
    setSearchStr(nextValue)

    if (nextValue.length > 0)
      debouncedSearch(nextValue)
  }

  const showResults = () => setResultsVisible(true)
  const changeLoading = (loading: boolean) => setLoading(loading)

  const clearResults = () => setResults([])

  const hideResults = () => {
    changeLoading(false)
    setResultsVisible(false)
    setResults([])
    setSearchStr("")
  }

  async function search(s: string): Promise<void> {
    const response = await httpClient.httpGet(`api/Search?s=${s}`)
    setResults(response.data as User[])
  }

  return (
    <SearchContext.Provider
      value={{
        searchStr,
        onSearchChange,
        search,
        results,
        resultsVisible,
        loading,
        showResults,
        hideResults,
        changeLoading,
        clearResults
      }}
    >
      { children }
    </SearchContext.Provider>
  )
}
