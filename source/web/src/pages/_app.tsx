import { Provider } from 'react-redux'
import store from '../heartwood/store'
import GlobalStyles from '../surface/styles/GlobalStyles'

function MyApp({ Component, pageProps }) {
  return (
    <Provider store={store}>
      <Component {...pageProps} />
      <GlobalStyles />
    </Provider>
  )
}

export default MyApp
