import { createContext, useState, useEffect, ReactNode } from 'react'

type i18nContextData = {
  locale: string
  changeLocale: (locale: string) => void
}

type i18nProviderProps = {
  children: ReactNode
}

export const defaultLocale = 'en-US'
export const locales = ['pt-BR', 'en-US']

export const i18nContext = createContext({} as i18nContextData)

export default function I18nProvider({children}: i18nProviderProps) {
  const [locale, setLocale] = useState<string>(navigator.language)

  useEffect(() => {
    if (locales.includes(navigator.language)) {
      setLocale(navigator.language)
    } else {
      setLocale(defaultLocale)
    }
  }, [navigator.language])

  const changeLocale = (locale: string): void => setLocale(locale)

  return (
    <i18nContext.Provider
      value={{
        locale,
        changeLocale
      }}
    >
      { children }
    </i18nContext.Provider>
  )
}