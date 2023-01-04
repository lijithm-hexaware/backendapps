const {
    render,
    screen,
    fireEvent,
    within,
    getByRole,
    act,
    cleanup,
} = require('@testing-library/react')
import '@testing-library/jest-dom/extend-expect'
import { Provider } from 'react-redux'
import store from 'store/store'
import {
    BrowserRouter as Router,
    Navigate,
    Route,
    Routes,
} from 'react-router-dom'
import { SettingsProvider } from 'common/contexts/SettingsContext'
import { MatxTheme } from 'components'
import EditProduct from '../EditProduct'
import { ProductAdded } from '../store/ProductSlice'
beforeAll(() => {
    store.dispatch(
        ProductAdded({
            id: 1,
            title: 'title',
            description: 'description',
            price: 41,
        })
    )
})

beforeEach(() => {
    render(
        <Provider store={store}>
            <SettingsProvider>
                <MatxTheme>
                    <Router>
                        <Routes>
                            <Route
                                path="/"
                                element={
                                    <Navigate to="Product/edit/1" replace />
                                }
                            />
                            <Route
                                path="Product/edit/:id"
                                element={<EditProduct />}
                            />
                        </Routes>
                    </Router>
                </MatxTheme>
            </SettingsProvider>
        </Provider>
    )
})

const clickAndWait = async (element) => {
    await act(async () => {
        fireEvent.click(element)
    })

    await act(async () => {
        jest.runOnlyPendingTimers()
    })
}

afterEach(cleanup)

describe('testing view of ProductEdit Component', () => {
    test('should render EditProduct and display the heading Edit Form', async () => {
        const headingNote = screen.getByText(/Edit Form/i)
        expect(headingNote).toBeInTheDocument()
    })

    test('should have all input fields present in the edit form', async () => {
        const saveProductButtonElement = screen.getByRole('button', {
            name: /save/i,
        })
        const titleElement = screen.getByLabelText(/Title/i)
        const descriptionElement = screen.getByLabelText(/Description/i)
        const priceElement = screen.getByLabelText(/Price/i)

        expect(saveProductButtonElement).toBeInTheDocument()

        expect(titleElement).toBeInTheDocument()
        expect(descriptionElement).toBeInTheDocument()
        expect(priceElement).toBeInTheDocument()
    })

    test('should be able to give inputs to all fields of Product edit form', async () => {
        const titleElement = screen.getByLabelText(/Title/i)
        const descriptionElement = screen.getByLabelText(/Description/i)
        const priceElement = screen.getByLabelText(/Price/i)

        fireEvent.change(titleElement, { target: { value: 'title' } })
        fireEvent.change(descriptionElement, {
            target: { value: 'description' },
        })
        fireEvent.change(priceElement, { target: { value: 33 } })

        expect(titleElement.value).toBe('title')

        expect(descriptionElement.value).toBe('description')

        expect(priceElement.value).toBe('33')
    })

    test('should return error message when save button is clicked on invalid form', async () => {
        jest.useFakeTimers()
        const titleElement = screen.getByLabelText(/Title/i)
        const descriptionElement = screen.getByLabelText(/Description/i)
        const priceElement = screen.getByLabelText(/Price/i)

        fireEvent.change(titleElement, { target: { value: '' } })
        fireEvent.change(descriptionElement, { target: { value: '' } })
        fireEvent.change(priceElement, { target: { value: '' } })
        await act(async () => {
            jest.runOnlyPendingTimers()
        })
        const saveProductButtonElement = screen.getByRole('button', {
            name: /save/i,
        })

        await clickAndWait(saveProductButtonElement)

        const errorList = await screen.findAllByText('this field is required')
        expect(errorList).toHaveLength(3)
    })
})
