export const getCookieFromKeyName = (key: string): string =>
  document.cookie.split('; ').find(row => row.startsWith(`${key}=`)).split('=')[1]