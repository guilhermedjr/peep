import { createContext, useContext, useState, useEffect, ReactNode } from 'react'
import { Peep } from '../contracts/Entity'
import { IParrotHttpClient, HttpStatusCode } from '../contracts/HttpClient'

type PeepsContextData = {
  isModalOpen: boolean,
  addPeep: (peep: Peep) => Promise<boolean>
  editPeep: (peep: Peep) => Promise<boolean>
}

type PeepsProviderProps = {
  children: ReactNode
  parrotHttpClient: IParrotHttpClient
}

export const PeepsContext = createContext({} as PeepsContextData)

export default function PeepsProvider({parrotHttpClient, children}: PeepsProviderProps) {
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false)
  const [peepToEdit, setPeepToEdit] = useState<Peep>()

  async function addPeep(peep: Peep): Promise<boolean> {
    const response = await parrotHttpClient.httpPost('peeps', peep)
    return response.status == HttpStatusCode.CREATED
  }

  async function editPeep(peep: Peep): Promise<boolean> {
    const response = await parrotHttpClient.httpPost('peeps', peep)
    return response.status == HttpStatusCode.NOCONTENT
  }

  return (
    <PeepsContext.Provider
      value={{
        isModalOpen,
        addPeep,
        editPeep
      }}
    >
      children
    </PeepsContext.Provider>
  )
}