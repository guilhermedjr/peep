export type HttpResponse<T> = {
  status: number,
  data?: T
}