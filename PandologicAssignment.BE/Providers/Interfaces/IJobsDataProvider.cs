using PandologicAssignment.Models;

namespace PandologicAssignment.Providers.Interfaces
{
    public interface IJobsDataProvider
    {
        public Dictionary<string, double> GetActiveJobsByRange(DateTime from , DateTime to);

        public Dictionary<string, double> GetPredictedJobViewsByRange(DateTime from, DateTime to);

        public Dictionary<string, double> GetJobViewsByRange(DateTime from, DateTime to);
    }
}
