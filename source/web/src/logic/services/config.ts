import IAxiosInstances from '../contracts/IAxiosInstances'
import axios from 'axios'

const AxiosInstances: IAxiosInstances = {
  Wings: axios.create({
    baseURL: 'https://localhost:44376/'
  }),
  Parrot: axios.create({
    baseURL: 'https://localhost:44364/'
  })
}

export default AxiosInstances