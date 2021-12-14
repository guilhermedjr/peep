import { createContext, useState, useEffect, useRef, ReactNode } from 'react'
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr'
import { SendDirectMessageDto } from '../contracts/Entity'

type DmContextData = {
  chat: any[]
  sendMessage: (message: SendDirectMessageDto) => Promise<void>
}

type DmProviderProps = {
  children: ReactNode
}

export const DmContext = createContext({} as DmContextData)

export default function DmProvider({ children }: DmProviderProps) {
  const [connection, setConnection] = useState<HubConnection>(null)
  const [chat, setChat] = useState([])
  const latestChat = useRef(null)

  latestChat.current = chat

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:44327/dm')
      .withAutomaticReconnect()
      .build()

    setConnection(newConnection)
  }, [])

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() => {
          connection.on('ReceiveDirectMessage', (message) => {
            const updatedChat = [...latestChat.current]
            updatedChat.push(message)
            setChat(updatedChat)
          })
        })
        .catch((e) => console.log('Connection to DM server failed: ', e))
    }
  }, [connection])

  async function sendMessage(message: SendDirectMessageDto): Promise<void> {
    if (connection.state == 'Connected') {
      try {
        await connection.send('SendDirectMessage', message)
      } catch (e) {
        console.log(e)
      }
    } else {
      alert('No connection to DM server yet.')
    }
  }

  return (
    <DmContext.Provider
      value={{
        chat,
        sendMessage,
      }}
    >
      { children }
    </DmContext.Provider>
  )
}
