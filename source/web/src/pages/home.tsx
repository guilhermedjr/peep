import Head from 'next/head'
import { Home } from '@components/Home'

export default function HomePage() {
  return (
    <>
      <Head>
        <title>Peep - Página Inicial</title>
      </Head>
      <body>
        <Home />
      </body>
    </>
  )
}