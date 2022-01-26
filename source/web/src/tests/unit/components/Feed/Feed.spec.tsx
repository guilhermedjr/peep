import { render, screen, within } from '@testing-library/react'
import { Feed } from '../../../../presentation/components/Feed'
import { UserTimelineContext } from '../../../../logic/contexts/UserTimelineContext'
import UserMock from '../../../mocks/entity/UserMock'

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