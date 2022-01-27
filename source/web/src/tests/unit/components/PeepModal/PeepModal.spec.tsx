import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { PeepModal } from '@components/PeepModal'
import { PeepsContext } from '@contexts/PeepsContext'
import UserMock from '@tests/mocks/entity/UserMock'

describe("Testing PeepModal component", () => {
  beforeAll(() => {
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
  })

  it("should be able to render user profile image (or default)", () => {
    const image = screen.getByTestId("peep-modal-profile-image")

    if (UserMock.ProfileImageUrl != null)
      expect(image).toHaveAttribute('src', UserMock.ProfileImageUrl)
    else
      expect(image).toHaveAttribute('src', 'defaultProfileImage.png')
  })

  /*it("should be able to enable send button if there is imputed content", () => {
    const sendButton = screen.getByTestId("send-peep-button")
    const textArea = screen.getByTestId("peep-textarea")

    userEvent.type(textArea, "Typing...")

    expect(sendButton).toBeEnabled()
  }) 
  
  it("should be able to disable send button if there is no imputed content", () => {
    const sendButton = screen.getByTestId("send-peep-button")
    const textArea = screen.getByTestId("peep-textarea")

    userEvent.clear(textArea)

    expect(sendButton).toBeDisabled()
  })*/
})