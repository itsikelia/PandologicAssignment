import './App.css';
import { useEffect, useState } from 'react';
import { useSelector, useDispatch } from "react-redux";
import { getJobViewsInfo } from "./features/JobViews";
import DateRangePicker from './components/dateRangePicker';
import JobViewsChart from './components/jobViewsChart';

function App() {
  const dateRange = useSelector((state) => state.dateRange.value);
  const dispatch = useDispatch();
  useEffect(async ()=>{
    dispatch(getJobViewsInfo({from:dateRange.from.format("yyyy-MM-DD"),to:dateRange.to.format("yyyy-MM-DD")}));
  },[]);
  return (
    <div className="App">
      <DateRangePicker/>
      <JobViewsChart/>
    </div>
  );
}

export default App;
