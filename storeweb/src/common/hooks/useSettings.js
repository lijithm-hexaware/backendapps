import { useContext } from 'react'
import SettingsContext from 'common/contexts/SettingsContext'

const useSettings = () => useContext(SettingsContext)

export default useSettings
