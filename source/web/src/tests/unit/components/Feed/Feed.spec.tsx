import { render, screen, within } from '@testing-library/react'
import { Feed } from '@components/Feed'
import { UserTimelineContext } from '@contexts/UserTimelineContext'
import UserMock from '@tests/mocks/entity/UserMock'

describe("Testing Feed component", () => {
  it("should be able to render the user peeps", () => {
    render(
      <UserTimelineContext.Provider
        value={{
          getUser: jest.fn(),
          user: UserMock
        }}
      >
        <Feed />
      </UserTimelineContext.Provider>
    )

    const feedComponent = screen.getByTestId("feed")
    const peeps = within(feedComponent).getAllByTestId("peep")

    expect(peeps.length).toBe(UserMock.Peeps.length)
  })  
})