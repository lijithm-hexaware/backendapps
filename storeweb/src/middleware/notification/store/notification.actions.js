import { clearNotification, showNotification } from "./notificationSlice";

export const showSuccess = (message) => (dispatch) => {
  const type = "success"
  return dispatch(showNotification({ message, type }));
};

export const showError = (message) => (dispatch) => {
  const type = "error"
  return dispatch(showNotification({ message, type }));
};

export const showWarning = (message) => (dispatch) => {
  const type = "warning"
  return dispatch(showNotification({ message, type }));
};

export const showInfo = (message) => (dispatch) => {
  const type = "info"
  return dispatch(showNotification({ message, type }));
};

export const removeNotification = () => (dispatch) => {
  dispatch(clearNotification());
};
