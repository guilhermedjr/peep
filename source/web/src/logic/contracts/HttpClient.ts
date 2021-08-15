export enum HttpStatusCode {
  OK = 200,
  CREATED = 201,
  NOCONTENT = 204,
  BADREQUEST = 400,
  UNAUTHORIZED = 401,
  FORBIDDEN = 403,
  NOTFOUND = 404,
  SERVERERROR = 500,
}

export type HttpResponse<T> = {
  status: HttpStatusCode
  data?: T
}

export interface IWingsHttpClient {
  httpGet<T>(url: string): Promise<HttpResponse<T>>
  httpPost<T>(url: string, body?: T): Promise<HttpResponse<T>>
  httpPut<T>(url: string, body?: T): Promise<HttpResponse<T>>
}

export interface IParrotHttpClient {
  httpGet<T>(url: string): Promise<HttpResponse<T>>
  httpPost<T>(url: string, body?: T): Promise<HttpResponse<T>>
  httpPut<T>(url: string, body?: T): Promise<HttpResponse<T>>
}
