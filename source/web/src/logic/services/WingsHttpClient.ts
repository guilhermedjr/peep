import AxiosInstances from './config'
import { AxiosResponse } from 'axios'
import { LoginDto, ApplicationUser } from '../contracts/Entity'
import { getCookieFromKeyName } from '../utils'

export default class WingsHttpClient {
  private readonly baseUrl = AxiosInstances.Wings
  private readonly headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type'
  }

  constructor() {}

  public async SignInWithGoogle(loginDto: LoginDto): Promise<ApplicationUser> {
    let response: AxiosResponse

    try {
      response = await this.baseUrl.post('api/Accounts/SignIn', loginDto, {
        headers: { ...this.headers }
      })
    } catch (error) {
        console.log(error)
        response = error.response
    }
    return response.data
  }

  public async GetLoggedUser(): Promise<ApplicationUser> {
    let response: AxiosResponse

    try {
      response = await this.baseUrl.get(`api/Accounts/${getCookieFromKeyName('user-id')}`, {
        headers: { 
          ...this.headers,
          'Authorization': `Bearer ${getCookieFromKeyName('peep-token')}` 
        }
      })
    } catch (error) {
        console.log(error)
        response = error.response
    }
    return response.data 
  }
}
