export type LoginProvider = 'GitHub' | 'Google' | 'Twitter'

export type AssociateExternalLoginDto = {
  Username: string
  Email: string
  AssociateToExistingAccount: boolean
  ExistingAccountEmail?: string
  LoginProvider: LoginProvider
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

export type CreateAccountDto = {
  Name: string
  Email?: string
  PhoneNumber?: string
  BirthDate: string
  Username: string
  Password: string
}

export type User = {
  readonly UserId?: string
  Name?: string
  Username?: string
  Bio: string
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
  ProfileImagePath?: string
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
