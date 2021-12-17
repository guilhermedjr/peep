import AxiosInstances from './config'
import { AxiosResponse } from 'axios'
import { LoginDto, ApplicationUserViewModel } from '../contracts/Entity'

export default class WingsHttpClient {
  private readonly baseUrl = AxiosInstances.Wings
  private readonly headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type'
  }

  constructor() {}

  public async SignInWithGoogle(loginDto: LoginDto): Promise<ApplicationUserViewModel> {
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
}
