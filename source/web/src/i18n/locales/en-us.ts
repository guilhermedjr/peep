import { IResource } from '../IResources'

const enUS: IResource = {
  PageTitles: {
    Login: 'Peep - Login or sign-up',
    Home: 'Peep - Home'
  },
  Login: {
    Slogan: 'Happening now',
    Message: 'Sign up to Peep even today.',
    SignIn: 'Login',
    SignUp: 'Sign Up',
    SocialAccount: {
      Google: {
        SignIn: 'Login with Google',
        SignUp: 'Sign up with Google'
      },
      Twitter: {
        SignIn: 'Login with Twitter',
        SignUp: 'Sign up with Twitter'
      },
      GitHub: {
        SignIn: 'Login with GitHub',
        SignUp: 'Sign up with GitHub'
      }
    }
  },
  CreateAccount: {
    Steps: {
      Basic: {
        Label: 'Create your account',
        UseEmailOption: 'Use email',
        UsePhoneOption: 'Use phone number',
        ForwardButton: 'Next'
      },
      CustomizeExperience: {
        Label: 'Customize your experience',
        EmailsReceiving: {
          Label: 'Get the most out of Peep',
          Description: 'Receive emails about your activity on Peep and recommendations.'
        },
        ConnectionsViaEmail: {
          Label: 'Connect with people you know',
          Description: 'Let others find your Peep account by email address.'
        },
        ForwardButton: 'Next'
      }
    },
    Inputs: {
      Name: 'Name',
      Email: 'E-mail',
      Phone: 'Phone number',
      BirthDate: {
        Label: 'Birth Date',
        Explication: 'This will not be publicly displayed. Confirm your own age, even if this account is for a business, a pet or others. Only over 14 years old will be allowed.',
        Day: 'Day',
        Month: 'Month',
        Year: 'Year'
      }
    }
  },
  User: {
    Info: {
      BirthDate: 'Born',
      JoinDate: 'Joined'
    },
    Connections: {
      Following: 'Following',
      Followers: 'Followers'
    }
  },
  Peep: {
    Publication: {
      Month: {
        January: 'Jan',
        February: 'Feb',
        March: 'Mar',
        April: 'Apr',
        May: 'May',
        June: 'June',
        July: 'July',
        August: 'Aug',
        September: 'Sep',
        October: 'Oct',
        November: 'Nov',
        December: 'Dec'
      }
    },
    Interactions: {
      Replies: 'Replies',
      Quotes: 'Quote Peeps',
      Reposts: 'Reposts',
      Likes: 'Likes'
    }
  },
  PeepModal: {
    Placeholder: "What's happening?"
  }
}

export default enUS