import store from 'store/store'
import { productAdded, productDeleted, productUpdated } from '../productSlice'

describe('testing product redux store reducers', () => {
    test('add product to store test', () => {
        let state = store.getState().product
        expect(state.entities).toHaveLength(0)
        const initialInput = {
            id: 1,
            title: 'title',
            description: 'description',
            price: 24,
        }
        store.dispatch(productAdded(initialInput))
        state = store.getState().product
        expect(state.entities).toHaveLength(1)
    })

    test('update product from store should change the length of the entities array in redux store', () => {
        const initialInput = {
            id: 2,
            title: 'title',
            description: 'description',
            price: 74,
        }
        store.dispatch(productAdded(initialInput))
        let state = store.getState().product
        expect(state.entities).toHaveLength(2)

        const updatedInput = {
            id: initialInput.id,
            title: 'title1',
            description: 'description1',
            price: 69,
        }
        store.dispatch(productUpdated(updatedInput))
        state = store.getState().product
        let changedProduct = state.entities.find((p) => p.id === 2)
        expect(changedProduct).toStrictEqual(updatedInput)
    })

    test('delete product from store should reduce the length of the entities array in redux store', () => {
        const initialInput = {
            id: 3,
            title: 'title',
            description: 'description',
            price: 41,
        }
        store.dispatch(productAdded(initialInput))
        let state = store.getState().product
        expect(state.entities).toHaveLength(3)

        store.dispatch(
            productDeleted({
                id: initialInput.id,
            })
        )
        state = store.getState().product
        expect(state.entities).toHaveLength(2)
    })
})
