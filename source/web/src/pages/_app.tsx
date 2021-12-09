import { Provider } from 'react-redux'
import { CookiesProvider } from 'react-cookie'
import { PeepsContext } from '../logic/contexts/PeepsContext'
import store from '../store'
import GlobalStyles from '../presentation/styles/GlobalStyles'

function MyApp({ Component, pageProps }) {
  return (
    <CookiesProvider>
      <Provider store={store}>
        <Component {...pageProps} />
        <GlobalStyles />
      </Provider>
    </CookiesProvider>
  )
}

export default MyApp
