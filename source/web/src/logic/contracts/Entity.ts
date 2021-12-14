export type LoginProvider = 'GitHub' | 'Google' | 'Twitter'

export type LoginDto = {
  Token: string
  IdToken: string
}

export type ApplicationUser = {
  readonly Id: string
  readonly Email: string
  readonly Name: string
  readonly Username: string
  readonly BirthDate: string
  readonly ProfileImageUrl: string
  readonly JoinedAt: string
}

export type Account = {
  readonly Id?: string
  Name: string
  Username: string
  AccountInfo?: AccountInfo
  AccountUserInfo?: AccountUserInfo
}

export type AccountInfo = {
  Email?: string
  PhoneNumber?: string
  readonly JoinedAt?: string
}

export type AccountUserInfo = {
  Bio: string
  Location?: string
  BirthDate?: string
  Website?: string
}

export type User = {
  readonly UserId?: string
  Name?: string
  Username?: string
  ProfileImageUrl?: string
  Bio?: string
  Location?: string
  BirthDate?: string
  Website?: string
  readonly JoinedAt?: string
  IsPrivateAccount?: boolean
  Following?: User[]
  Followers?: User[]
  readonly Peeps?: Peep[]
  readonly Replies?: Peep[]
  readonly UserNests?: Nest[]
  readonly Nests?: Nest[]
  readonly FollowRequests?: User[]
  readonly BlockedUsers?: User[]
  readonly MutedUsers?: User[]
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

export interface Peep {
  readonly PeepId?: string
  User: User
  readonly Date?: string
  readonly Time?: string
  Description: string
  Source: EPeepSource
  ReplyRescriction: EPeepReplyRestriction
  readonly Quotes?: Quote[]
  readonly Reposts?: Account[]
  readonly Likes?: Account[]
  readonly Replies?: Reply[]
}

export interface Quote extends Peep {
  QuotedPeep: Peep
}

export interface Reply extends Peep {
  RepliedPeep: Peep
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

export type SendDirectMessageDto = {
  SenderId: string
  ReceiverId: string
  Text: string
}
