import React from 'react'
import useSettings from 'common/hooks/useSettings'
import SecondarySidebarToggle from './SecondarySidebarToggle'
import SecondarySidebarContent from './SecondarySidebarContent'
import SecondarySidenavTheme from '../MatxTheme/SecondarySidenavTheme/SecondarySidenavTheme'

const SecondarySidebar = () => {
    const { settings } = useSettings()
    const secondarySidebarTheme =
        settings.themes[settings.secondarySidebar.theme]

    return (
        <SecondarySidenavTheme theme={secondarySidebarTheme}>
            {settings.secondarySidebar.open && <SecondarySidebarContent />}
            <SecondarySidebarToggle />
        </SecondarySidenavTheme>
    )
}

export default SecondarySidebar
