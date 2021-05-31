export type Account = {
  Id: string
  Name: string
  Username: string
  AccountInfo?: AccountInfo
  AccountUserInfo?: AccountUserInfo
}

type AccountInfo = {
  Email?: string
  PhoneNumber?: string
  JoinedAt: string
  Following: number
  Followers: number
}

type AccountUserInfo = {
  Bio: string
  Location?: string
  BirthDate?: string
  Website?: string
}