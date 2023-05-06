using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test.FactoryMethod.Creators
{
    public class Campaign5Creator : CampaignCreator
    {
        private const bool newCustomer = true;
        private const string templateName = "Template C";
        private const int sendHour = 10;
        private const int sendMinute = 05;
        private const int campingPriority = 4;

        public override CampaignModel Create()
        {
            return new CampaignModel()
            {
                Priority = campingPriority,
                TemplateName = templateName,
                Time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, sendHour, sendMinute, 0),
                Predicate = delegate (CustomerSendingModel customer) { return customer.NewCustomer == newCustomer; },
                Receivers = new List<CustomerSendingModel>()
            };
        }
    }
}