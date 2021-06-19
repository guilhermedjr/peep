import { PeepHasContent } from "./Peep";

export type PeepProps = {
  hasContent: PeepHasContent[]
  user: string
  userProfileImagePath?: string
  username: string
  isRepost: boolean
  date: string
  time: string
  description?: string
  imageContentPath?: string
}