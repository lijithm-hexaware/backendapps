import React from 'react'
import { styled } from '@mui/system'
import { SimpleCard } from 'components'
import { useSelector } from 'react-redux'
const Container = styled('div')(({ theme }) => ({
    margin: '30px',
    [theme.breakpoints.down('sm')]: {
        margin: '16px',
    },
    '& .breadcrumb': {
        marginBottom: '30px',
        [theme.breakpoints.down('sm')]: {
            marginBottom: '16px',
        },
    },
}))
const Home = () => {
    const loading = useSelector((state) => state.loading)
    return <Container>
        <SimpleCard title="Welcome">
                {loading ? (
                    'Loading...'
                ) : (
                    <div >
                        Welcome to React Matx CRUD
                    </div>
                )}
            </SimpleCard>
    </Container>
}

export default Home
