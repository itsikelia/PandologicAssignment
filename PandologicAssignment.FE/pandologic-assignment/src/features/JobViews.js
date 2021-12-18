import { createSlice ,createAsyncThunk} from "@reduxjs/toolkit";
import jobViewsEndpoint from "../services/jobViewsService";
const initialStateValue = { jobViewsData:{} };
const { getJobViewsData } = jobViewsEndpoint();
export const jobViewsSlice = createSlice({
  name: "jobViews",
  initialState: { value: initialStateValue },
  reducers: {
  },
    extraReducers: (builder) => {
        // Add reducers for additional action types here, and handle loading state as needed
        builder.addCase(getJobViewsInfo.fulfilled, (state, action) => {
          state.value = {jobViewsData:action.payload}
        })
      },
  
});

export const getJobViewsInfo = createAsyncThunk(
    'jobViews/getJobViewsInfo',
    async ({from,to}) => {
      const response = await getJobViewsData(from , to)
      return response.data
    }
  )
export default jobViewsSlice.reducer;