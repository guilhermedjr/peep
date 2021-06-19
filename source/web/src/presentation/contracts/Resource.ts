type Resource = {
  Login: {
    Slogan: string,
    Message: string,
    SignIn: string,
    SignUp: string
  },
  CreateAccount: {
    Steps: {
      Basic: {
        Label: string,
        UseEmailOption: string,
        UsePhoneOption: string,
        ForwardButton: string
      },
      CustomizeExperience: {
        Label: string,
        EmailsReceiving: {
          Label: string,
          Description: string
        },
        ConnectionsViaEmail: {
          Label: string,
          Description: string
        }
      }

    },
    Inputs: {
      Name: string,
      Email: string,
      Phone: string,
      BirthDate: {
        Label: string,
        Explication: string,
        Day: string,
        Month: string,
        Year: string
      }
    },
  }
  User: {
    Info: {
      BirthDate: string,
      JoinDate: string
    },
    Connections: {
      Following: string,
      Followers: string
    }
  }
  Peep: {
    Publication: {
      Month: {
        January: string,
        February: string,
        March: string,
        April: string,
        May: string,
        June: string,
        July: string,
        August: string,
        September: string,
        October: string,
        November: string,
        December: string
      }
    }
    Interactions: {
      Replies: string,
      Quotes: string,
      Reposts: string,
      Likes: string
    }
  }
}

export default Resource 