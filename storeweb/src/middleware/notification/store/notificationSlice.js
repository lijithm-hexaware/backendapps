import { createSlice } from "@reduxjs/toolkit";
const initialState = {
  openDialog: false,
  message: "",
  type: "success" || "error" || "warn" || "info"
};
export const notificationSlice = createSlice({
  name: "notification",
  initialState: initialState,
  reducers: {
    showNotification(state, action) {
      state.openDialog = true;
      const { message, type } = action.payload;
      state.message = message;
      state.type = type;
    },
    clearNotification(state) {
      state.openDialog = false;
      // state.message = "";
      // state.type = "";
    },
  },
});

export const { showNotification, clearNotification } = notificationSlice.actions

export default notificationSlice.reducer