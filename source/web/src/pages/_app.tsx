import { CookiesProvider } from 'react-cookie'
import AuthProvider from '../logic/contexts/AuthContext'
import UserTimelineProvider from '../logic/contexts/UserTimelineContext'
import PeepsProvider from '../logic/contexts/PeepsContext'
import SearchProvider from '../logic/contexts/SearchContext'
import GlobalStyles from '../presentation/styles/GlobalStyles'
import RouteGuard from '../presentation/HOCs/RouteGuard'

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
        <UserTimelineProvider>
          <AuthProvider>
            <PeepsProvider>
              <SearchProvider>
                <RouteGuard>
                  <Component {...pageProps} />
                </RouteGuard>
                <GlobalStyles />
              </SearchProvider>
            </PeepsProvider>
          </AuthProvider>
        </UserTimelineProvider>
      </CookiesProvider>
    </SafeHydrate>
  )
}

export default MyApp
