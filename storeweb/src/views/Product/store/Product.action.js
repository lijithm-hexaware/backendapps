import { createAsyncThunk } from '@reduxjs/toolkit'
import { showSuccess } from 'middleware/notification/store/notification.actions'
import axios from '../../../axios'

const endPoint = 'Product'

export const fetchProduct = createAsyncThunk(
    'Product/fetchProduct',
    async () => {
        const response = await axios.get(`/${endPoint}`)
        const Product = await response.data
        return Product
    }
)

export const addProduct = createAsyncThunk(
    'Product/addProduct',
    async (data, thunkAPI) => {
        const response = await axios.post(`/${endPoint}`, data)
        const Product = await response.data
        thunkAPI.dispatch(showSuccess('Product added successfully'))
        return Product
    }
)

export const editProduct = createAsyncThunk(
    'Product/editProduct',
    async (data, thunkAPI) => {
        const response = await axios.put(`/${endPoint}/${data.id}`, data)
        const Product = await response.data
        thunkAPI.dispatch(showSuccess('Product updated successfully'))
        return Product
    }
)

export const deleteProduct = createAsyncThunk(
    'Product/deleteProduct',
    async (data, thunkAPI) => {
        const response = await axios.delete(`/${endPoint}/${data.id}`)
        const status = await response.status
        if (status === 200) {
            thunkAPI.dispatch(
                showSuccess('Selected Product deleted successfully.')
            )
            return data.id
        }
    }
)
