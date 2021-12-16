import { createContext, useContext, useState, useEffect, ReactNode } from 'react'
import { Peep, AddPeepDto } from '../contracts/Entity'
import { HttpStatusCode } from '../contracts/HttpClient'
import ParrotHttpClient from '../services/ParrotHttpClient'

type PeepsContextData = {
  isModalOpen: boolean,
  openModal: () => void,
  closeModal: () => void,
  addPeep: (addPeepDto: AddPeepDto) => Promise<boolean>
}

type PeepsProviderProps = {
  children: ReactNode
}

export const PeepsContext = createContext({} as PeepsContextData)

export default function PeepsProvider({children}: PeepsProviderProps) {
  const httpClient = new ParrotHttpClient()
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false)
  const [peepToEdit, setPeepToEdit] = useState<Peep>()
  
  const openModal = (): void => {
    setIsModalOpen(true)
  }

  const closeModal = (): void => {
    setIsModalOpen(false)
  }

  async function addPeep(addPeepDto: AddPeepDto): Promise<boolean> {
    const response = await httpClient.httpPost('api/Peeps', addPeepDto)
    return response.status == HttpStatusCode.OK
  }
  
  return (
    <PeepsContext.Provider
      value={{
        isModalOpen,
        openModal,
        closeModal,
        addPeep,
      }}
    >
      { children }
    </PeepsContext.Provider>
  )
}