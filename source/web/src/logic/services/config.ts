import IAxiosInstances from '../contracts/IAxiosInstances'
import axios from 'axios'

const AxiosInstances: IAxiosInstances = {
  Wings: axios.create({
    baseURL: process.env.NEXT_PUBLIC_WINGS_URL,
  }),
  Parrot: axios.create({
    baseURL: process.env.NEXT_PUBLIC_PARROT_URL,
  })
}

export default AxiosInstances
