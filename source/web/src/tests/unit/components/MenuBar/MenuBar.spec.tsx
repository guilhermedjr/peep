import { render, screen, fireEvent } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MenuBar } from '../../../../presentation/components/MenuBar'
import { PeepModal } from '../../../../presentation/components/PeepModal'
import { AuthContext } from '../../../../logic/contexts/AuthContext'
import { PeepsContext } from '../../../../logic/contexts/PeepsContext'
import UserMock from '../../../mocks/entity/UserMock'

describe("Testing MenuBar component", () => {
  beforeAll(() => {
    render(
      <AuthContext.Provider
        value={{
          login: jest.fn(),
          loggedUser: UserMock,
          isAuthenticated: true
        }}
      >
        <PeepsContext.Provider
          value={{
            isModalOpen: false,
            openModal: jest.fn(),
            closeModal: jest.fn(),
            addPeep: jest.fn()
          }}
        >
          <MenuBar />
        </PeepsContext.Provider>
      </AuthContext.Provider>
    )
  })

  /*it("should be able to open PeepModal component", () => {
    render(
      <PeepsContext.Provider
        value={{
          isModalOpen: false,
          openModal: jest.fn(),
          closeModal: jest.fn(),
          addPeep: jest.fn()
        }}
      >
        <PeepModal />
      </PeepsContext.Provider>
    )

    const button = screen.getByTestId("peep-button")
    //userEvent.click(button)
    fireEvent.click(button)

    const peepModal = screen.getByTestId("peep-modal")
    
    expect(peepModal).toBeVisible()
  })*/
})