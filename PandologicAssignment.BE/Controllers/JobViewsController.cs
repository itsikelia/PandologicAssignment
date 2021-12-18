using Microsoft.AspNetCore.Mvc;
using PandologicAssignment.Models;
using PandologicAssignment.Providers.Interfaces;
using PandologicAssignment.ViewModels;

namespace PandologicAssignment.Controllers
{
    [Route("[controller]")]
    public class JobViewsController : Controller
    {
        private readonly IJobsDataProvider _jobsDataProvider;
        public JobViewsController(IJobsDataProvider jobsDataProvider)
        {
            _jobsDataProvider = jobsDataProvider;
        }

        [HttpPost]
        [Route("GetJobViewDataByDateRange")]
        public ActionResult GetJobViewDataByDateRange([FromBody] GetJobViewDataRequest data)
        {
            var predictedJobsDictionary = _jobsDataProvider.GetPredictedJobViewsByRange(data.From, data.To);
            var jobsViewsDictionary = _jobsDataProvider.GetJobViewsByRange(data.From, data.To);
            var activeJobsDictionary = _jobsDataProvider.GetActiveJobsByRange(data.From, data.To);
            GetJobViewDataResponse response = new GetJobViewDataResponse();
            for (int i = 0; data.From.AddDays(i) <= data.To; i++)
            {
                string date = data.From.AddDays(i).ToShortDateString();
                GetJobViewDayData dayIData = new GetJobViewDayData();
                dayIData.PredictedJobs = predictedJobsDictionary[date];
                dayIData.JobViews = jobsViewsDictionary[date];
                dayIData.ActiveJob = activeJobsDictionary[date];
                response.Data.Add(date, dayIData);
            }
            return Ok(response);
        }
    }
}
