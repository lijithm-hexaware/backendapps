import React from 'react'
import { Alert, Slide, Snackbar } from '@mui/material'
import { useDispatch, useSelector } from 'react-redux';
import { removeNotification } from './store/notification.actions';

function TransitionUp(props) {
    return <Slide {...props} direction="left" />;
}


const Notification = () => {

    const dispatch = useDispatch();
    const { openDialog, message, type } = useSelector((state) => state.notification);
    const handleClose = () => {
        dispatch(removeNotification());
    };
    return ( 
            <Snackbar
                anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
                key={`bottom-right`}
                autoHideDuration={6000}
                open={openDialog}
                onClose={handleClose}
                ContentProps={{
                    'aria-describedby': `message-${type}`,
                }}
                transitionDuration={{ enter: 500, exit: 400 }}
                TransitionComponent={TransitionUp}
                message={<span id="message-id">{message}</span>}
                sx={{
                    width: 400}}
            >
                <Alert
                    onClose={handleClose}
                    sx={{ m: 1 }}
                    severity={type || "success"}
                    variant="filled"
                >
                    {message}
                </Alert>
            </Snackbar>
    )
}

export default Notification