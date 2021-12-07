import AxiosInstances from './config'
import { LoginProvider, LoginDto, ApplicationUser } from '../contracts/Entity'
import { getGoogleTokens } from '../services/FirebaseAuth'

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

  public async SignInWithGoogle(): Promise<ApplicationUser> {
    const loginDto: LoginDto = getGoogleTokens()
    return this.baseUrl.post('api/Accounts/SignIn', loginDto, {
      headers: {
        ...this.headers,
        'Authorization': `Bearer ${loginDto.Token}` 
      }
    }).then(
      response => response.data
    )
  }
}
