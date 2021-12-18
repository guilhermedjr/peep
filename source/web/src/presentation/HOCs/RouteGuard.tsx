import { useContext, useState, useEffect } from 'react'
import { useRouter } from 'next/router'
import { AuthContext } from '../../logic/contexts/AuthContext'

export default function RouteGuard({ children }): JSX.Element {
  const router = useRouter()
  const { isAuthenticated } = useContext(AuthContext)
  const [authorized, setAuthorized] = useState<boolean>(false)

  const hideContent = () => setAuthorized(false)

  useEffect(() => {
    authCheck(router.asPath)

    router.events.on('routeChangeStart', hideContent)
    router.events.on('routeChangeComplete', authCheck)

    return () => {
      router.events.off('routeChangeStart', hideContent)
      router.events.off('routeChangeComplete', authCheck)
    }
  }, [])


  const authCheck = (url: string) => {
    const publicPaths = ['/'];
    const path = url.split('?')[0]

    if (!isAuthenticated && !publicPaths.includes(path)) {
      setAuthorized(false)
      router.push({
        pathname: '/',
        query: { returnUrl: router.asPath }
      })
    } else {
      setAuthorized(true)
    }
  }

  return (authorized && children)
}

