import Chart from 'react-google-charts';
import { useEffect, useState } from 'react';
import moment from 'moment';
import { useSelector} from "react-redux";

function JobViewsChart() {
  const jobViews = useSelector((state) => state.jobViews.value);
  const [chartData , setChartData] = useState([]);
  const [chartHAxisTicks ,setChartHAxisTicks] = useState([]);
   useEffect(()=>{
    getJobViewsInfo()
  },[jobViews])
  const getJobViewsInfo = ()=>{
    //[date , cummolative job views , cummolative preditcted views ,active jobs ]
    let jobData = [[
      'Day',
      'Cummolative job views',
      'Cummolative preditcted views ',
      'Active jobs',
    ]]
    let jobViewsData=jobViews?.jobViewsData?.data;
    let newChartTicks = [];
    jobViewsData && Object.keys(jobViewsData).map(date=>{
      jobData.push([moment(date , "DD/MM/yyyy").toDate() , jobViewsData[date].jobViews ,  jobViewsData[date].predictedJobs , jobViewsData[date].activeJob ])
      newChartTicks.push(moment(date , "DD/MM/yyyy").toDate())
    }) 
    setChartData(jobData);
    setChartHAxisTicks(newChartTicks)
   }

  return (
    <div >
      <Chart
  width={'1200px'}
  height={'600px'}
  chartType="ComboChart"
  loader={<div>Loading Chart</div>}
  data={
    chartData
  }
  options={{
    title: 'Cumulative job views vs. prediction',
    vAxes: [{ title: 'Job Views' ,maxValue:30},{title:'Jobs' ,maxValue:25}],
    hAxis: { slantedText:true, slantedTextAngle:90 , format:'MMM,d' , showTextEvery:1 , ticks :chartHAxisTicks},
    pointShape: {
      type: 'triangle',
      rotation: 180
    },
    focusTarget: 'category',
    legend: 'bottom',
    seriesType: 'line',
    series: { 
      2: { type: 'bars' ,color:"gray" , dataOpacity:"0.3" ,targetAxisIndex: 1 }, 
      0:{type:'lines', color:"#94bf37", pointSize:10 , pointShape:"circle" ,pointFillColor:"white" ,targetAxisIndex: 0} ,
      1:{type:'lines', color:"#71c6d7" , pointSize:15,targetAxisIndex: 0}},
  }}
  rootProps={{ 'data-testid': '1' }}
/> 
    </div>
  );
}

export default JobViewsChart;
