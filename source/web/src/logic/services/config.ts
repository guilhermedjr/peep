import IAxiosInstances from '../contracts/IAxiosInstances'
import axios from 'axios'

const AxiosInstances: IAxiosInstances = {
  Wings: axios.create({
    baseURL: 'https://localhost:5001/',
  }),
  Parrot: axios.create({
    baseURL: 'https://localhost:44364/',
  }),
  Stork: axios.create({
    baseURL: 'https://localhost:44327/',
  }),
}

export default AxiosInstances
