import { Peep } from '../Peep'
import { Peeps } from './styles'

export function Feed() {
  const userTeste = 'Ednaldo Pereira'
  const usernameTeste = 'oednaldopereira'

  return (
    <Peeps>
      <Peep user={userTeste} username={usernameTeste} 
        hasContent={[
          {type: 0,
          isPresent: true},
          {type: 1,
            isPresent: false},
          {type: 2,
            isPresent: false},
        ]}
        isRepost={false}
        date={'13/06/2021'}
        time={'14:02:00'}
        description={'Agradecer  exatamente  a todos  que enviaram  mensagens  de aniversário  ontem  muito obrigado  vocês  fazem  desta  obra  de Ednaldo Pereira  cada  vez mais um sucesso Ednaldo Pereira'}
        />
      <Peep user={userTeste} username={usernameTeste} 
         hasContent={[
          {type: 0,
          isPresent: true},
          {type: 1,
            isPresent: true},
          {type: 2,
            isPresent: false},
        ]}
        isRepost={false}
        date={'11/06/2021'}
        time={'16:44:00'}
        description={'Adesivo  desculpa  montagem  Ednaldo Pereira'}
        imageContentPath={'desculpaAmigoComiSuaEsposa_EdnaldoPereira.jpg'}
        />
      <Peep user={userTeste} username={usernameTeste}
         hasContent={[
          {type: 0,
          isPresent: false},
          {type: 1,
            isPresent: true},
          {type: 2,
            isPresent: false},
        ]}
        isRepost={true}
        date={'10/06/2021'}
        time={'17:26:00'}
        imageContentPath={'vamosOuvirEdnaldoPereira.png'}
      />
    </Peeps> 
  )   
}