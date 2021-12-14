export const getCookieFromKeyName = (key: string): string =>
  typeof document != undefined ? document.cookie.split('; ').find(row => row.startsWith(`${key}=`)).split('=')[1] : ''