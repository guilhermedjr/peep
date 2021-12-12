import { useContext } from 'react'
import { i18nContext, defaultLocale } from '../contexts/i18nContext'
import Resources from '../../i18n/locales/index'

export default function useTranslation() {
  const { locale } = useContext(i18nContext)    

  const t = (key: string) => {
    return Resources[locale][key] || Resources[defaultLocale][key] || ""
  }

  return { t, locale }
}