import IAxiosInstances from '../contracts/IAxiosInstances'
import axios from 'axios'

const AxiosInstances: IAxiosInstances = {
  Wings: axios.create({
    baseURL: 'https://peep-wings.herokuapp.com/',
  }),
  Parrot: axios.create({
    baseURL: process.env.PARROT_URL,
  }),
  Stork: axios.create({
    baseURL: process.env.STORK_URL,
  }),
}

export default AxiosInstances
