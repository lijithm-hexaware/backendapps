import { useContext } from 'react'
import NotificationContext from 'common/contexts/NotificationContext'

const useNotification = () => useContext(NotificationContext)

export default useNotification
