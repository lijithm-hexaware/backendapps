import { configureStore } from '@reduxjs/toolkit'
import ProductReducer from '../views/Product/store/ProductSlice'
import { createLogger } from 'redux-logger'
import notificationReducer from '../middleware/notification/store/notificationSlice'
let middlewares = []
if (process.env.NODE_ENV === `development`) {
    const logger = createLogger({
        collapsed: (getState, action, logEntry) => !logEntry.error,
    })
    middlewares.push(logger)
}
export default configureStore({
    reducer: {
        notification: notificationReducer,
        Product: ProductReducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(middlewares),
    devTools: process.env.NODE_ENV !== 'production',
})
