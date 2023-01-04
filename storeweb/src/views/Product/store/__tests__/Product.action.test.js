import axios from '../../../../axios'
import MockAdapter from 'axios-mock-adapter'
import store from 'store/store'
import {
    fetchProduct,
    addProduct,
    editProduct,
    deleteProduct,
} from '../product.action'

const getProductListResponse = [
    {
        id: 1,
        title: 'title',
        description: 'description',
        price: 6,
    },
]

const addProductListResponse = (data) => {
    return { id: 2, ...data }
}
const editProductListResponse = (data) => {
    return data
}

describe('should test Product redux tooklit asyncThunk api action and redux store updation', () => {
    const mock = new MockAdapter(axios)
    const endPoint = 'product'
    test('Should be able to fetch the product list and update product redux store', async () => {
        mock.onGet(`/${endPoint}`).reply(200, getProductListResponse)
        const result = await store.dispatch(fetchProduct())
        const productList = result.payload
        expect(result.type).toBe('product/fetchProduct/fulfilled')
        expect(productList).toEqual(getProductListResponse)

        const state = store.getState().product
        expect(state.entities).toEqual(productList)
    })

    test('Should be able to add new product to list and make post api and update product redux store', async () => {
        const body = {
            title: 'title',
            description: 'description',
            price: 47,
        }
        mock.onPost(`/${endPoint}`, body).reply(
            201,
            addProductListResponse(body)
        )
        const result = await store.dispatch(addProduct(body))
        const productItem = result.payload
        expect(result.type).toBe('product/addProduct/fulfilled')
        expect(productItem).toEqual(addProductListResponse(body))

        const state = store.getState().product
        expect(state.entities).toContainEqual(addProductListResponse(body))
    })

    test('Should be able to edit product in list and make put api call and update product redux store', async () => {
        const body = {
            id: 1,
            title: 'title',
            description: 'description',
            price: 10,
        }
        mock.onPut(`/${endPoint}/${body.id}`, body).reply(
            201,
            editProductListResponse(body)
        )
        const result = await store.dispatch(editProduct(body))
        const productItem = result.payload
        expect(result.type).toBe('product/editProduct/fulfilled')
        expect(productItem).toEqual(editProductListResponse(body))

        const state = store.getState().product
        let changedProduct = state.entities.find((p) => p.id === body.id)
        expect(changedProduct.name).toEqual(body.name)
    })

    test('Should be able to delete product in list and update product redux store', async () => {
        const input = {
            id: 2,
        }
        mock.onDelete(`/${endPoint}/${input.id}`, input).reply(200)
        let state = store.getState().product
        const initialLength = state.entities.length
        const result = await store.dispatch(deleteProduct(input))
        const deletId = result.payload
        expect(result.type).toBe('product/deleteProduct/fulfilled')
        expect(deletId).toEqual(input.id)

        state = store.getState().product
        const updateLength = initialLength - 1
        expect(state.entities.length).toEqual(updateLength)
    })
})
