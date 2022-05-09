import { ApolloProvider } from '@apollo/client'
import { CookiesProvider } from 'react-cookie'
import client from '@services/apollo'
import AuthProvider from '@contexts/AuthContext'
import UserTimelineProvider from '@contexts/UserTimelineContext'
import PeepsProvider from '@contexts/PeepsContext'
import SearchProvider from '@contexts/SearchContext'
import GlobalStyles from '@styles/GlobalStyles'
import RouteGuard from '@HOCs/RouteGuard'

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
      <ApolloProvider client={client}>
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
      </ApolloProvider>
    </SafeHydrate>
  )
}

export default MyApp
