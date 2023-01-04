const { render, screen, cleanup } = require('@testing-library/react')
import '@testing-library/jest-dom/extend-expect'
import { Provider } from 'react-redux'
import store from 'store/store'
import { BrowserRouter as Router } from 'react-router-dom'
import { SettingsProvider } from 'common/contexts/SettingsContext'
import { MatxTheme } from 'components'
import ProductList from '../ProductList'
import axios from '../../../axios'
import MockAdapter from 'axios-mock-adapter'

afterEach(cleanup)

test('should render Product rows when api response has data', async () => {
    const endPoint = 'product'
    const getProductListResponse = [
        {
            id: 1,
            title: 'title1',
            description: 'description1',
            price: 85,
        },
    ]
    const mock = new MockAdapter(axios)
    mock.onGet(`/${endPoint}`).reply(200, getProductListResponse)
    render(
        <Provider store={store}>
            <SettingsProvider>
                <MatxTheme>
                    <Router>
                        <ProductList />
                    </Router>
                </MatxTheme>
            </SettingsProvider>
        </Provider>
    )
    const productTitleCell = await screen.findByText(/title1/i)

    expect(productTitleCell).toHaveTextContent(/title1/i)
    mock.reset()
})
