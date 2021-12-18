using PandologicAssignment.Models;
using PandologicAssignment.Providers.Interfaces;

namespace PandologicAssignment.Providers
{
    public class JobsDataProvider : IJobsDataProvider
    {
        public Dictionary<string, double> GetActiveJobsByRange(DateTime from, DateTime to)
        {
            Dictionary<string, double> activeJobs = new Dictionary<string, double>();

            using (var context = new JobContext())
            {
                for (int i = 0; from.AddDays(i) <= to; i++)
                {
                    var query = context.ActiveJobs.Where(activeJob => activeJob.PostDate.Date <= from.AddDays(i).Date && from.AddDays(i).Date <= activeJob.EndDate.Date).ToList();
                    activeJobs.Add(from.AddDays(i).ToShortDateString(), query.Count);
                }
                return activeJobs;
            }
        }

        public Dictionary<string, double> GetJobViewsByRange(DateTime from, DateTime to)
        {
            Dictionary<string, double> viewsPerDay = new Dictionary<string, double>();

            using (var context = new JobContext())
            {
                for (int i = 0; from.AddDays(i) <= to; i++)
                {
                    var query = context.JobViews.Where(jobView => 
                        jobView.ViewDate.Date == from.AddDays(i).Date).ToList();
                    viewsPerDay.Add(from.AddDays(i).ToString("dd/MM/yyyy"), query.Count);
                }
                return viewsPerDay;
            }
        }



        public Dictionary<string, double> GetPredictedJobViewsByRange(DateTime from, DateTime to)
        {
            Dictionary<string, double> predictedViewsPerDay = new Dictionary<string, double>();

            using (var context = new JobContext())
            {
                for (int i = 0; from.AddDays(i) <= to; i++)
                {

                    var activeJobsPerIDay = context.ActiveJobs.Where(jobView => jobView.PostDate.Date <= from.AddDays(i).Date && from.AddDays(i).Date <= jobView.EndDate.Date);
                    var activeJobsWithPredictedViews = context.Jobs.Join(activeJobsPerIDay,
                                                                       job => job.JobId,
                                                                       activeJob => activeJob.JobId,
                                                                      (job, activeJob) => new
                                                                      {
                                                                          JobId = job.JobId,
                                                                          PredictedViews = job.PredictedViewsPerDay,
                                                                      }
                                                                       );
                    predictedViewsPerDay.Add(from.AddDays(i).ToShortDateString(), activeJobsWithPredictedViews.Sum(job=>job.PredictedViews));
                }


                return predictedViewsPerDay;
            }

        }
    }
}
