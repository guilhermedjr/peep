import { Provider } from 'react-redux'
import store from '../../logic/store'
import GlobalStyles from '../styles/GlobalStyles'

function MyApp({ Component, pageProps }) {
  return (
    <Provider store={store}>
      <Component {...pageProps} />
      <GlobalStyles />
    </Provider>
  )
}

export default MyApp
