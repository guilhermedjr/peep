import { AxiosResponse } from 'axios'
import AxiosInstances from './config'
import { HttpResponse, IParrotHttpClient } from '../contracts/HttpClient'

export default class ParrotHttpClient implements IParrotHttpClient {
  private readonly baseUrl = AxiosInstances.Parrot
  private readonly headers = {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  }

  constructor() {}

  public async httpGet<T>(url: string): Promise<HttpResponse<T>> {
    let response: AxiosResponse

    try {
      response = await this.baseUrl.get(url, {
        headers: this.headers,
      })
    } catch (error) {
      console.log(error)
      response = error.response
    }

    return {
      status: response.status,
      data: response.data,
    }
  }

  public async httpPost<T>(url: string, body?: T): Promise<HttpResponse<T>> {
    let response: AxiosResponse

    try {
      response = await this.baseUrl.post(url, {
        body: typeof body != 'undefined' ? body : null,
        headers: this.headers,
      })
    } catch (error) {
      console.log(error)
      response = error.response
    }

    return {
      status: response.status,
      data: response.data,
    }
  }

  public async httpPut<T>(url: string, body?: T): Promise<HttpResponse<T>> {
    let response: AxiosResponse

    try {
      response = await this.baseUrl.put(url, {
        body: typeof body != 'undefined' ? body : null,
        headers: this.headers,
      })
    } catch (error) {
      console.log(error)
      response = error.response
    }

    return {
      status: response.status,
      data: response.data,
    }
  }
}
