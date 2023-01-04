import React, { lazy } from 'react'
import Loadable from 'components/Loadable/Loadable'

const ProductList = Loadable(lazy(() => import('./ProductList')))
const EditProduct = Loadable(lazy(() => import('./EditProduct')))
const AddProduct = Loadable(lazy(() => import('./AddProduct')))

const ProductRoutes = [
    {
        path: '/Product',
        element: <ProductList />,
    },
    {
        path: '/Product/edit/:id',
        element: <EditProduct />,
    },
    {
        path: '/Product/add',
        element: <AddProduct />,
    },
]

export default ProductRoutes
