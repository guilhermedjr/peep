import { Provider } from 'react-redux'
import { CookiesProvider } from 'react-cookie'
import I18nProvider from '../presentation/contexts/i18nContext'
import PeepsProvider from '../logic/contexts/PeepsContext'
import SearchProvider from '../logic/contexts/SearchContext'
import store from '../store'
import GlobalStyles from '../presentation/styles/GlobalStyles'

// Disable SSR and SSG (temporary)
function SafeHydrate({ children }) {
  return (
    <div suppressHydrationWarning>
      {typeof window === 'undefined' ? null : children}
    </div>
  )
}

function MyApp({ Component, pageProps }) {
  return (
    <SafeHydrate>
      <CookiesProvider>
        <I18nProvider>
          <PeepsProvider>
            <SearchProvider>
              <Provider store={store}>
                <Component {...pageProps} />
                <GlobalStyles />
              </Provider>
            </SearchProvider>
          </PeepsProvider>
        </I18nProvider>
      </CookiesProvider>
    </SafeHydrate>
  )
}

export default MyApp
