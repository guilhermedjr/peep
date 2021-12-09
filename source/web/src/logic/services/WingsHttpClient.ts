import AxiosInstances from './config'
import { AxiosResponse } from 'axios'
import { LoginDto, ApplicationUser } from '../contracts/Entity'

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
        headers: {
          ...this.headers,
          'Authorization': `Bearer ${loginDto.Token}` 
        }
      })
    } catch (error) {
        console.log(error)
        response = error.response
    }
    console.log(response)
    return response.data 
  }
}
