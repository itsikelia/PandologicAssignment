namespace PandologicAssignment.ViewModels
{
    public class GetJobViewDataResponse
    {
        public Dictionary<string,GetJobViewDayData> Data { get; set; }
        public GetJobViewDataResponse()
        {
            Data = new Dictionary<string, GetJobViewDayData>(); 
        }
    }

    public class GetJobViewDayData
    {
        public double PredictedJobs { get; set; }

        public double JobViews { get; set; }

        public double ActiveJob { get; set; }
    }

}
