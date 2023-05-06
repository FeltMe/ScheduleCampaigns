using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test.FactoryMethod.Creators
{
    public class Campaign4Creator : CampaignCreator
    {
        private const decimal depositeMoreThan = 100m;
        private const string templateName = "Template A";
        private const int sendHour = 10;
        private const int sendMinute = 15;
        private const int campingPriority = 3;

        public override CampaignModel Create()
        {
            return new CampaignModel()
            {
                Priority = campingPriority,
                TemplateName = templateName,
                Time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, sendHour, sendMinute, 0),
                Predicate = delegate (Customer customer) { return customer.Deposit > depositeMoreThan; },
                Receivers = new List<Customer>()
            };
        }
    }
}
