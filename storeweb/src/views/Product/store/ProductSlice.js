import { createSlice } from '@reduxjs/toolkit'
import { fetchProduct } from './Product.action'
import { addProduct } from './Product.action'
import { editProduct } from './Product.action'
import { deleteProduct } from './Product.action'

const fetchProductExtraReducer = {
    [fetchProduct.pending]: (state, action) => {
        state.loading = true
    },
    [fetchProduct.fulfilled]: (state, action) => {
        state.entities = [...action.payload]
        state.loading = false
    },
    [fetchProduct.rejected]: (state, action) => {
        state.loading = false
    },
}

const addProductExtraReducer = {
    [addProduct.pending]: (state, action) => {
        state.loading = true
    },
    [addProduct.fulfilled]: (state, action) => {
        state.entities.push(action.payload)
        state.loading = false
    },
    [addProduct.rejected]: (state, action) => {
        state.loading = false
    },
}

const editProductExtraReducer = {
    [editProduct.pending]: (state, action) => {
        state.loading = true
    },
    [editProduct.fulfilled]: (state, action) => {
        const { id, title, description, price } = action.payload
        const existingProduct = state.entities.find(
            (Product) => Product.id.toString() === id.toString()
        )
        if (existingProduct) {
            existingProduct.title = title
            existingProduct.description = description
            existingProduct.price = price
        }
        state.loading = false
    },
    [editProduct.rejected]: (state, action) => {
        state.loading = false
    },
}

const deleteProductExtraReducer = {
    [deleteProduct.pending]: (state, action) => {
        state.loading = true
    },
    [deleteProduct.fulfilled]: (state, action) => {
        const id = action.payload
        const existingProduct = state.entities.find(
            (Product) => Product.id.toString() === id.toString()
        )
        if (existingProduct) {
            state.entities = state.entities.filter(
                (Product) => Product.id !== id
            )
        }
        state.loading = false
    },
    [deleteProduct.rejected]: (state, action) => {
        state.loading = false
    },
}
const ProductSlice = createSlice({
    name: 'Product',
    initialState: {
        entities: [],
        loading: false,
    },
    reducers: {
        ProductAdded(state, action) {
            state.entities.push(action.payload)
        },
        ProductUpdated(state, action) {
            const { id, title, description, price } = action.payload
            const existingProduct = state.entities.find(
                (Product) => Product.id.toString() === id.toString()
            )
            if (existingProduct) {
                existingProduct.title = title
                existingProduct.description = description
                existingProduct.price = price
            }
        },
        ProductDeleted(state, action) {
            const { id } = action.payload
            const existingProduct = state.entities.find(
                (Product) => Product.id.toString() === id.toString()
            )
            if (existingProduct) {
                state.entities = state.entities.filter(
                    (Product) => Product.id !== id
                )
            }
        },
    },
    extraReducers: {
        ...fetchProductExtraReducer,
        ...addProductExtraReducer,
        ...editProductExtraReducer,
        ...deleteProductExtraReducer,
    },
})

export const { ProductAdded, ProductUpdated, ProductDeleted } =
    ProductSlice.actions

export default ProductSlice.reducer
