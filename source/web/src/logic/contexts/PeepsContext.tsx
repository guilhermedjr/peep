import { createContext, useContext, useState, useEffect, ReactNode } from 'react'
import { Peep } from '../contracts/Entity'
import { IHttpClient, HttpStatusCode } from '../contracts/HttpClient'

type PeepsContextData = {
  isModalOpen: boolean,
  openModal: () => void,
  closeModal: () => void,
  addPeep: (peep: Peep) => Promise<boolean>
  editPeep: (peep: Peep) => Promise<boolean>
}

type PeepsProviderProps = {
  children: ReactNode
  parrotHttpClient: IHttpClient
}

export const PeepsContext = createContext({} as PeepsContextData)

export default function PeepsProvider({parrotHttpClient, children}: PeepsProviderProps) {
  const [isModalOpen, setIsModalOpen] = useState<boolean>(true)
  const [peepToEdit, setPeepToEdit] = useState<Peep>()
  
  const openModal = (): void => {
    setIsModalOpen(true)
  }

  const closeModal = (): void => {
    setIsModalOpen(false)
  }

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
        openModal,
        closeModal,
        addPeep,
        editPeep
      }}
    >
      children
    </PeepsContext.Provider>
  )
}