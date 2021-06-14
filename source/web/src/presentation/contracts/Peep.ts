export enum EPeepContentType {
  Description,
  ImageContent,
  Poll
}

export type PeepHasContent = {
  type: EPeepContentType
  isPresent: boolean
}