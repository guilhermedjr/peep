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
    return this.baseUrl.get('api/SocialAccounts/Providers').then(
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
  }
}
