import { createSlice } from "@reduxjs/toolkit";
import moment from "moment";

const initialStateValue = { from: moment().startOf('month'), to:moment()};

export const dateRangeSlice = createSlice({
  name: "dateRange",
  initialState: { value: initialStateValue },
  reducers: {
    updateFrom: (state, action) => {
      state.value = {...state.value , from:action.payload}
    },
    updateTo: (state, action) => {
        state.value = {...state.value , to:action.payload}
      }
  },
});

export const { updateFrom, updateTo } = dateRangeSlice.actions;

export default dateRangeSlice.reducer;