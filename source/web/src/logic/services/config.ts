import IAxiosInstances from '../contracts/IAxiosInstances'
import axios from 'axios'

const AxiosInstances: IAxiosInstances = {
  Wings: axios.create({
    baseURL: 'https://ancient-basin-99825.herokuapp.com/https://localhost:44376/',
  }),
  Parrot: axios.create({
    baseURL: process.env.PARROT_URL,
  }),
  Stork: axios.create({
    baseURL: process.env.STORK_URL,
  }),
}

export default AxiosInstances
