import { EPeepReplyRestriction, EPeepSource, User } from '../../../logic/contracts/Entity'

const UserMock: User = {
  Id: '98DEA457-643D-4796-AD3C-5793ADD3F5F6',
  Email: 'email@gmail.com',
  Name: 'User',
  Username: '@user',
  ProfileImageUrl: null,
  BirthDate: '',
  JoinedAt: '',
  Bio: null,
  Location: null,
  Website: null,
  PrivateAccount: false,
  VerifiedAccount: false,
  Following: [],
  Followers: [],
  UserNests: [],
  Nests: [],
  FollowRequests: [],
  BlockedUsers: [],
  MutedUsers: [],
  Peeps: [
    {
       Id: '44060BF4-8325-42CA-A91C-172A94494600',
       UserId: '98DEA457-643D-4796-AD3C-5793ADD3F5F6',
       PublicationDate: '2022-01-25',
       PublicationTime: '16:00:00',
       TextContent: 'Peep teste 1',
       Source: EPeepSource.PeepWebApp,
       ReplyRestriction: EPeepReplyRestriction.Everyone,
       QuotedPeepId: null,
       RepliedPeepId: null,
       Quotes: [],
       Replies: [],
       Rps: [],
       Likes: []
    },
    {
      Id: 'EA7AA8BF-A2AC-4A59-B9EE-3BD10DF7BBFF',
      UserId: '98DEA457-643D-4796-AD3C-5793ADD3F5F6',
      PublicationDate: '2022-01-25',
      PublicationTime: '16:10:00',
      TextContent: 'Peep teste 2',
      Source: EPeepSource.PeepForAndroid,
      ReplyRestriction: EPeepReplyRestriction.Followed,
      QuotedPeepId: null,
      RepliedPeepId: null,
      Quotes: [],
      Replies: [],
      Rps: [],
      Likes: []
   },
  ]   
}

export default UserMock