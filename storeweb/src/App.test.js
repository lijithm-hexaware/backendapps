const { render, screen } = require("@testing-library/react");
import App from './App'
import '@testing-library/jest-dom/extend-expect';
import {
    BrowserRouter as Router,
  } from "react-router-dom";
  
test('should render App Component and match the project name', async () => {
    render(<Router ><App /></Router>)
    const websiteName = await screen.findByText(/storeweb/i)
    expect(websiteName).toBeInTheDocument()
    expect(websiteName).toHaveTextContent("storeweb")
});