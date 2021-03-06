import { render, screen } from '@testing-library/react'
import { Profile } from '@components/Profile'
import { UserTimelineContext } from '@contexts/UserTimelineContext'
import { AuthContext } from '@contexts/AuthContext'
import UserMock from '@tests/mocks/entity/UserMock'

describe("Testing Profile component", () => {
  beforeAll(() => {
    render(
      <UserTimelineContext.Provider
        value={{
          getUser: jest.fn(),
          user: UserMock
        }}
      >
        <AuthContext.Provider
          value={{
            login: jest.fn(),
            loggedUser: UserMock,
            isAuthenticated: true
          }}
        >
          <Profile />
        </AuthContext.Provider>
      </UserTimelineContext.Provider>
    )
  })

  it("should be able to render user profile image (or default)", () => {
    const image = screen.getByTestId("profile-profile-image")

    if (UserMock.ProfileImageUrl != null)
      expect(image).toHaveAttribute('src', UserMock.ProfileImageUrl)
    else
      expect(image).toHaveAttribute('src', 'defaultProfileImage.png')
  }) 
})
