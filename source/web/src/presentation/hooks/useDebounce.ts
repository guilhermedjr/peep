import { useCallback } from 'react'
import debounce from 'lodash/debounce'

export default function useDebounce(callback, delay) {
  const debouncedFn = useCallback(
    debounce((...args) => callback(...args), delay),
    [delay]
  )
  return debouncedFn
}