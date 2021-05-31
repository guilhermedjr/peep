type HttpMethod = 'post' | 'get' | 'put' | 'delete'

enum HttpStatusCode {
  OK = 200,
  CREATED = 201,
  NOCONTENT = 204,
  BADREQUEST = 400,
  UNAUTHORIZED = 401,
  FORBIDDEN = 403,
  NOTFOUND = 404,
  SERVERERROR = 500
}

type HttpRequest = {
  url: string
  method: HttpMethod
  body?: any
  headers?: any
}

type HttpResponse<T = any> = {
  statusCode: HttpStatusCode
  body?: T
  headers?: any
}

export interface IHttpClient {
  httpGet: ()
  httpPost: ()
  httpPut()
  httpDelete():
}
