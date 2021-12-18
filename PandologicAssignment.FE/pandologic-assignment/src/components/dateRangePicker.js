
import { useEffect, useState } from 'react';
import { useSelector, useDispatch } from "react-redux";
import { updateFrom, updateTo } from "../features/dateRange";
import { getJobViewsInfo } from "../features/JobViews";
import TextField from '@mui/material/TextField';
import MuiDateRangePicker from '@mui/lab/DateRangePicker';
import AdapterMoment from '@mui/lab/AdapterMoment';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import Box from '@mui/material/Box';

function DateRangePicker() {

  const dateRange = useSelector((state) => state.dateRange.value);
  const jobViews = useSelector((state) => state.jobViews.value);
  const dispatch = useDispatch();

  const handleFromChange = async(newVal) =>{
    if(!newVal[0] || !newVal[1]) return;
    dispatch(updateFrom(newVal[0]));
    dispatch(updateTo(newVal[1]));
    dispatch(getJobViewsInfo({from:newVal[0].format("yyyy-MM-DD"),to:newVal[1].format("yyyy-MM-DD")}));
  }
  
    return (
        <div className="rangePicker">
      <LocalizationProvider dateAdapter={AdapterMoment}>
        <MuiDateRangePicker
          startText="Date from"
          endText="Date to"
          inputFormat="DD/MM/yyyy"
          value={[dateRange.from,dateRange.to]}
          onChange={handleFromChange}
          renderInput={(startProps, endProps) => (
            <>
              <TextField {...startProps} />
              <Box sx={{ mx: 2 }}> to </Box>
              <TextField {...endProps} />
            </>
          )}
        />
      </LocalizationProvider>
      </div>
    );
}

export default DateRangePicker;
