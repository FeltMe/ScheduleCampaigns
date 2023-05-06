using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test.FactoryMethod.Creators
{
    public class Campaign2Creator : CampaignCreator
    {
        private const int aboveTheAge = 45;
        private const string templateName = "Template B";
        private const int sendHour = 10;
        private const int sendMinute = 5;
        private const int campingPriority = 2;

        public override CampaignModel Create()
        {
            return new CampaignModel()
            {
                Priority = campingPriority,
                TemplateName = templateName,
                Time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, sendHour, sendMinute, 0),
                Predicate = delegate (CustomerSendingModel customer) { return customer.Age > aboveTheAge; },
                Receivers = new List<CustomerSendingModel>()
            };
        }
    }
}
