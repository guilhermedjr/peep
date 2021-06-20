import { createContext, useContext, useState, useEffect, ReactNode } from 'react'

type AuthContextData = {}

type AuthProviderProps = {
  children: ReactNode
} 

export const AuthContext = createContext({} as AuthContextData)

export function AuthProvider({children}: AuthProviderProps) {
  return (
    <AuthContext.Provider
      value={{

      }}
    >
      children
    </AuthContext.Provider>
  )
}