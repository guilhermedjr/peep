import Document, { Html, Head, Main, NextScript } from 'next/document'
import React from 'react'
import Routes from '../presentation/Routes'

export default class MyDocument extends Document {
  render() {
    return (
      <Html>
        <Head></Head>
        <body>
          <Main />
          <NextScript />
          <Routes />
        </body>
      </Html>
    )
  }
}
