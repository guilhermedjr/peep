import { render, screen } from '@testing-library/react'
import { PeepComponent } from '@components/Peep'
import UserMock from '@tests/mocks/entity/UserMock'

describe("Testing Peep component", () => {
  beforeAll(() => {
    render(
      <PeepComponent peep={UserMock.Peeps[0]} user={UserMock} />
    )
  })

  it("should be able to render user profile image (or default)", () => {
    const image = screen.getByTestId("peep-profile-image")

    if (UserMock.ProfileImageUrl != null)
      expect(image).toHaveAttribute('src', UserMock.ProfileImageUrl)
    else
      expect(image).toHaveAttribute('src', 'defaultProfileImage.png')
  })
})