import store from 'store/store';
import { showError } from 'middleware/notification/store/notification.actions';
import axios from 'axios'

let apiUrl = process.env.REACT_APP_API_URL
let options = {
    baseURL: apiUrl,
    headers: {
        "Content-type": "application/json",
    },
};
const axiosInstance = axios.create(options)

axiosInstance.interceptors.response.use(
    (response) => {
        return response
    }
        ,
    (error) =>{
        let message = error.message || error.response.data.message
        if(message === "Network Error") {
            message = "Something went wrong. Please contact application administrator"
        }
        else if (error.response.status === 404) {
            message = "Some problem reaching API server. Please contact application administrator"
        }
        else if (error.response.status === 500) {
            message = "Some internal server error. Please contact application administrator"
        }
        else if (error.response.status === 401) {
            message = "Your request can not be authorized. Please contact application administrator"
        }
        console.log(message)
        store.dispatch(
            showError(message));
        return Promise.reject(
            (error.response && error.response.data) || "Something went wrong. Please contact application administrator"
        )
    }
)
export default axiosInstance
