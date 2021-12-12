import { Provider } from 'react-redux'
import { CookiesProvider } from 'react-cookie'
import { appWithTranslation } from 'next-i18next'
import I18nProvider from '../presentation/contexts/i18nContext'
import store from '../store'
import GlobalStyles from '../presentation/styles/GlobalStyles'

function MyApp({ Component, pageProps }) {
  return (
      <CookiesProvider>
        <I18nProvider>
          <Provider store={store}>
            <Component {...pageProps} />
            <GlobalStyles />
          </Provider>
        </I18nProvider>
      </CookiesProvider>
  )
}

export default appWithTranslation(MyApp)
