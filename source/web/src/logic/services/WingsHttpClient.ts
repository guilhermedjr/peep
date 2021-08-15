import { AxiosResponse } from 'axios'
import AxiosInstances from './config'
import { LoginProvider, AssociateExternalLoginDto } from '../contracts/Entity'

export default class WingsHttpClient {
  private readonly baseUrl = AxiosInstances.Wings
  private readonly headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type'
  }

  constructor() {}

  public async SignUpWithSocialAccount(externalLoginDto: AssociateExternalLoginDto): Promise<void> {
    await this.baseUrl.post(
      'api/SocialAccounts/Associate', externalLoginDto)
  }

  public async SignInWithSocialAccount(loginProvider: LoginProvider): Promise<void> {
    await this.baseUrl.get(
      `api/SocialAccounts/SignIn?provider=${loginProvider}`
    )
  }

  // public async httpGet<T>(url: string): Promise<HttpResponse<T>> {
  //   let response: AxiosResponse

  //   try {
  //     response = await this.baseUrl.get(url, {
  //       headers: this.headers,
  //     })
  //   } catch (error) {
  //     console.log(error)
  //     response = error.response
  //   }

  //   return response != undefined
  //     ? {
  //         status: response.status,
  //         data: response.data,
  //       }
  //     : null
  // }

  // public async httpPost<T>(url: string, body?: T): Promise<HttpResponse<T>> {
  //   let response: AxiosResponse

  //   try {
  //     response = await this.baseUrl.post(url, {
  //       body: typeof body != 'undefined' ? body : null,
  //       headers: this.headers,
  //     })
  //   } catch (error) {
  //     console.log(error)
  //     response = error.response
  //   }

  //   return {
  //     status: response.status,
  //     data: response.data,
  //   }
  // }

  // public async httpPut<T>(url: string, body?: T): Promise<HttpResponse<T>> {
  //   let response: AxiosResponse

  //   try {
  //     response = await this.baseUrl.put(url, {
  //       body: typeof body != 'undefined' ? body : null,
  //       headers: this.headers,
  //     })
  //   } catch (error) {
  //     console.log(error)
  //     response = error.response
  //   }

  //   return {
  //     status: response.status,
  //     data: response.data,
  //   }
  // }
}
