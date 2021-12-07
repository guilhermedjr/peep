import axios from 'axios'
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

  public async GetSocialLoginProviders(): Promise<LoginProvider[]> {
    return this.baseUrl.get('api/Accounts/Providers').then(
      response => response.data
    )
  }

  public async SignUpWithSocialAccount(externalLoginDto: AssociateExternalLoginDto): Promise<void> {
    await this.baseUrl.post(
      'api/SocialAccounts/Associate', externalLoginDto)
  }

  public async SignInWithSocialAccount(loginProvider: LoginProvider): Promise<void> {
    await this.baseUrl.get(
      `api/SocialAccounts/SignIn?provider=${loginProvider}`
    )
    // await axios.get(
    //   'https://ancient-basin-99825.herokuapp.com/https://github.com/login/oauth/authorize?client_id=a5f035e6fb6eb4c1ed11&scope=&response_type=code&redirect_uri=http%3A%2F%2Fpeep-wings.herokuapp.com%2Fsignin-github&state=CfDJ8N4BxMdd0XRNqF8KROf-L9988OmUtba9zPvTpJAq2i1IBYhwqxvNY-xDhKeQvnXHHrSD-3OrD6pZkiGssfHKgG_pahMDzCg-p7rKPpEl81swbhNrTbuq79ubJjOBIyEWAzghJtrX8rOwZ-MFC4gdzBArFA4SU4idoVWHK1v5o0a1BL4zOYyuyOh84ZLNSW3hvTAdIgzHrtCqHfp8LXgIEk5W7V9GPnjIM88M8wo0EdaNV8i2-wcKYOijtf5mzRA1AR87J5GlSvQ1Dz5gzLYlRD4')
  }
}
