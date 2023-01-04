const { render, screen } = require("@testing-library/react");
import Home from '../Home'
import '@testing-library/jest-dom/extend-expect';
import store from "store/store"
import { Provider } from 'react-redux';
test('should render Home Component and match the heading', async () => {
    render(<Provider store={store}><Home /></Provider>)
    const welcomeNote = screen.getByText(/Welcome to React Matx CRUD/i)
    expect(welcomeNote).toBeInTheDocument()
    expect(welcomeNote).toHaveTextContent("Welcome to React Matx CRUD")
});