export type LoginDto = {
  Token: string
  IdToken: string
}

export type ApplicationUserViewModel = {
  Id: string
  Email: string
  Name: string
  Username: string
  ProfileImageUrl: string
  BirthDate: string
  JoinedAt: string
}

export type User = {
  Id: string
  Email: string
  Name: string
  Username: string
  ProfileImageUrl: string | null
  BirthDate: string
  JoinedAt: string
  Bio: string | null
  Location: string | null
  Website: string | null
  PrivateAccount: boolean
  VerifiedAccount: boolean
  Following: User[]
  Followers: User[]
  UserNests: Nest[]
  Nests: Nest[]
  FollowRequests: User[]
  BlockedUsers: User[]
  MutedUsers: User[]
  Peeps: Peep[]
}

export enum EPeepSource {
  PeepWebApp,
  PeepForAndroid,
  PeepForIPhone,
  PeepForAlexia,
  PeepForElectrolux,
  PeepForSpaceXSuperHeavy,
}

export enum EPeepReplyRestriction {
  Everyone,
  Followed,
  Mentioned,
}

export interface AddPeepDto {
  UserId: string
  TextContent: string
  Source?: EPeepSource
  ReplyRestriction?: EPeepReplyRestriction
  QuotedPeepId?: string
  RepliedPeepId?: string
}

export type Peep = {
  Id: string
  UserId: string
  PublicationDate: string
  PublicationTime: string
  TextContent: string
  Source: EPeepSource
  ReplyRestriction: EPeepReplyRestriction
  QuotedPeepId: string | null,
  RepliedPeepId: string | null,
  Quotes: Peep[],
  Replies: Peep[],
  Rps: User[],
  Likes: User[]
}

export type Nest = {
  readonly NestId?: string
  OwnerId: string
  IsPublic: boolean
  Name: string
  Description: string
  readonly Members?: User[]
  readonly Followers?: User[]
  readonly CreatedAt?: string
}