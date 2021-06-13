import { Provider } from 'react-redux'
import { PeepsContext } from '../logic/contexts/PeepsContext'
import store from '../logic/store'
import GlobalStyles from '../presentation/styles/GlobalStyles'

function MyApp({ Component, pageProps }) {
  return (
    <Provider store={store}>
      <Component {...pageProps} />
      <GlobalStyles />
    </Provider>
  )
}

export default MyApp
