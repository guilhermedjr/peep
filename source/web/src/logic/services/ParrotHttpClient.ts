import { AxiosResponse } from 'axios'
import AxiosInstances from './config'
import { HttpResponse, IHttpClient } from '../contracts/HttpClient'
import { getCookieFromKeyName } from '../utils'

export default class ParrotHttpClient implements IHttpClient {
  private readonly baseUrl = AxiosInstances.Parrot
  private readonly headers = {
    Accept: 'application/json',
    'Content-Type': 'application/json',
    // 'Authorization': `Bearer ${getCookieFromKeyName('peep-token')}` 
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
      return;
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
        body: typeof body != 'undefined' ? JSON.stringify(body) : null,
        headers: this.headers,
      })
    } catch (error) {
      console.log(error)
      return;
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
      return;
    }

    return {
      status: response.status,
      data: response.data,
    }
  }
}
