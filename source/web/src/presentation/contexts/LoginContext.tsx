import { createContext, useContext, useState, useEffect, ReactNode, Dispatch, SetStateAction } from 'react'

type LoginContextData = {
  isSignUpModalOpen: boolean,
  isSignInModalOpen: boolean,
  openSignUpModal: () => void,
  closeSignUpModal: () => void,
  openSignInModal: () => void,
  closeSignInModal: () => void
}

type LoginProviderProps = {
  children: ReactNode
}

export const LoginContext = createContext({} as LoginContextData)

export default function LoginProvider({children}: LoginProviderProps) {
  const [isSignUpModalOpen, setIsSignUpModalOpen] = useState<boolean>(false)
  const [isSignInModalOpen, setIsSignInModalOpen] = useState<boolean>(false)

  const openSignUpModal = (): void => {
    setIsSignUpModalOpen(true)
  }

  const closeSignUpModal = (): void => {
    setIsSignUpModalOpen(false)
  }

  const openSignInModal = (): void => {
    setIsSignInModalOpen(true)
  }

  const closeSignInModal = (): void => {
    setIsSignInModalOpen(false)
  }

  return (
    <LoginContext.Provider 
      value={{
        isSignUpModalOpen,
        isSignInModalOpen,
        openSignUpModal,
        closeSignUpModal,
        openSignInModal,
        closeSignInModal
      }}
    >
      children
    </LoginContext.Provider>
  )

}