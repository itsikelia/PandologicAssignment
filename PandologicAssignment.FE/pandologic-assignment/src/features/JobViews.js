import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import jobViewsEndpoint from "../services/jobViewsService";
const initialStateValue = { jobViewsData: {} };
const { getJobViewsData } = jobViewsEndpoint();
export const jobViewsSlice = createSlice({
  name: "jobViews",
  initialState: { value: initialStateValue, isError: false, isLoading: false },
  reducers: {
  },
  extraReducers: (builder) => {
    // Add reducers for additional action types here, and handle loading state as needed
    builder.addCase(getJobViewsInfo.fulfilled, (state, action) => {
      state.isError = false;
      state.isLoading = false;
      state.value = { jobViewsData: action.payload };
    });
    builder.addCase(getJobViewsInfo.rejected, (state, action) => {
      state.isError = true;
      state.isLoading = false;
    })
    builder.addCase(getJobViewsInfo.pending, (state, action) => {
      state.isLoading = true;
    })
  },

});

export const getJobViewsInfo = createAsyncThunk(
  'jobViews/getJobViewsInfo',
  async ({ from, to }) => {
    let response = await getJobViewsData(from, to);
    return response.data;
  });
export default jobViewsSlice.reducer;