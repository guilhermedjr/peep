import Resource from '../presentation/contracts/Resource'

export const ptBR: Resource = {
  Login: {
    Slogan: 'Acontecendo agora',
    Message: 'Inscreva-se no Peep hoje mesmo.',
    SignIn: 'Entrar',
    SignUp: 'Inscrever-se'
  },
  CreateAccount: {
    Steps: {
      Basic: {
        Label: 'Criar sua conta',
        UseEmailOption: 'Usar o e-mail',
        UsePhoneOption: 'Usar o telefone',
        ForwardButton: 'Avançar'
      },
      CustomizeExperience: {
        Label: 'Personalize sua experiência',
        EmailsReceiving: {
          Label: 'Aproveite o Peep ao máximo',
          Description: 'Receba e-mails sobre sua atividade no Peep e recomendações.'
        },
        ConnectionsViaEmail: {
          Label: 'Conecte-se com as pessoas que você conhece',
          Description: 'Permita que outras pessoas encontrem sua conta do Peep pelo endereço de e-mail.'
        },
        ForwardButton: 'Avançar'
      }
    },
    Inputs: {
      Name: 'Nome',
      Email: 'E-mail',
      Phone: 'Número de telefone',
      BirthDate: {
        Label: 'Data de nascimento',
        Explication: 'Isso não será exibido publicamente. Confirme sua própria idade, mesmo se esta conta for de empresa, de um animal de estimação ou outros. Somente maiores de 14 anos serão permitidos no Peep.',
        Day: 'Dia',
        Month: 'Mês',
        Year: 'Ano'
      }
    }
  },
  User: {
    Info: {
      BirthDate: 'Nascido em',
      JoinDate: 'Entrou em'
    },
    Connections: {
      Following: 'Seguindo',
      Followers: 'Seguidores'
    }
  },
  Peep: {
    Publication: {
      Month: {
        January: 'Jan',
        February: 'Fev',
        March: 'Mar',
        April: 'Abr',
        May: 'Mai',
        June: 'Jun',
        July: 'Jul',
        August: 'Ago',
        September: 'Set',
        October: 'Out',
        November: 'Nov',
        December: 'Dez'
      }
    },
    Interactions: {
      Replies: 'Respostas',
      Quotes: 'Peeps com comentário',
      Reposts: 'Repostagens',
      Likes: 'Curtidas'
    }
  }
}

export const enUS: Resource = {
  Login: {
    Slogan: 'Happening now',
    Message: 'Sign up to Peep even today.',
    SignIn: 'Login',
    SignUp: 'Sign Up'
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
  }
}