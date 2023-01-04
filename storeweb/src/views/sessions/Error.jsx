import React from 'react'
import { Button } from '@mui/material'
import { Box, styled } from '@mui/system'
import { useNavigate } from 'react-router-dom'
import { H1, H4 } from 'components/Typography'

const FlexBox = styled(Box)(() => ({
    display: 'flex',
    alignItems: 'center',
}))

const JustifyBox = styled(FlexBox)(() => ({
    maxWidth: 320,
    flexDirection: 'column',
    justifyContent: 'center',
}))

const IMG = styled('img')(() => ({
    width: '100%',
    marginBottom: '32px',
}))

const ErrorRoot = styled(FlexBox)(() => ({
    width: '100%',
    alignItems: 'center',
    justifyContent: 'center',
    height: '100vh !important',
}))

export const myErrorHandler = (error, info) => {
    console.log(error)
    console.log(info)
}
const ErrorFallback = ({ error, resetErrorBoundary }) => {
    const navigate = useNavigate()
    return (
        <ErrorRoot>
            <JustifyBox>
                <IMG src="/assets/images/illustrations/designer.svg" alt="" />
                <H1>Something Went Wrong</H1>
                <H4>Contact Administrator</H4>
                <Button
                    color="primary"
                    variant="contained"
                    sx={{ textTransform: 'capitalize' }}
                    onClick={() => {
                        navigate('/')
                        resetErrorBoundary()
                    }}
                >
                    Back to Home
                </Button>
            </JustifyBox>
        </ErrorRoot>
    )
}

export default ErrorFallback
