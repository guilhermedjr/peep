import { useContext } from 'react'
import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { SideBar } from '@components/SideBar'
import { SearchContext } from '@contexts/SearchContext'

/*const { searchStr, onSearchChange, showResults, hideResults, loading, changeLoading } 
  = useContext(SearchContext)

describe("Testing search bar", () => {
  beforeAll(() => {
    render(
      <SearchContext.Provider
        value={{
          searchStr: searchStr,
          onSearchChange: onSearchChange,
          search: jest.fn(),
          results: [],
          resultsVisible: false,
          loading: false,
          showResults: jest.fn(),
          hideResults: jest.fn(),
          changeLoading: jest.fn(),
          clearResults: jest.fn()
        }}
      >
        <SideBar />
      </SearchContext.Provider>
    )
  })

  it("should be able to search", () => {
    const input = screen.getByTestId("input-search")
    userEvent.type(input, "just searching...")
    
  })
  
  /*it("should be able to hide results while the user is typing", () => {

  })*/
//})
