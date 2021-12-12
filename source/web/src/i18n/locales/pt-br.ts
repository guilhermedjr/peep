import { IResource } from '../IResources'

const ptBR: IResource = {
  PageTitles: {
    Login: 'Peep - Entre ou cadastre-se',
    Home: 'Peep - Home'
  },
  Login: {
    Slogan: 'Acontecendo agora',
    Message: 'Inscreva-se no Peep hoje mesmo.',
    SignIn: 'Entrar',
    SignUp: 'Inscrever-se',
    SocialAccount: {
      Google: {
        SignIn: 'Entrar com Google',
        SignUp: 'Inscrever-se com Google'
      },
      Twitter: {
        SignIn: 'Entrar com Twitter',
        SignUp: 'Inscrever-se com Twitter'
      },
      GitHub: {
        SignIn: 'Entrar com GitHub',
        SignUp: 'Inscrever-se com GitHub'
      }
    }
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
  },
  PeepModal: {
    Placeholder: 'O que está acontecendo?'
  }
}

export default ptBR