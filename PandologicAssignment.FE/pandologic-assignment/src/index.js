import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { configureStore } from "@reduxjs/toolkit";
import { Provider } from "react-redux";
import dateRangeReducer from "./features/dateRange";
import jobViewsReducer from "./features/JobViews";


const store = configureStore({
  reducer: {
    dateRange:dateRangeReducer,
    jobViews:jobViewsReducer
  },
});

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);
