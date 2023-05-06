using MyApplicationName.BLL.FactoryMethod;
using MyApplicationName.Models.Models;

namespace MyApplicationName.BLL.FactoryMethod.Creators
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
			var templateModel = new TemplateModel(templateName);
			templateModel.TemplateString = base.GetTemplateText(templateName);
			return new CampaignModel()
			{
				Priority = campingPriority,
				TemplateModel = templateModel,
				Time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, sendHour, sendMinute, 0),
				Predicate = delegate (Customer customer) { return customer.NewCustomer == newCustomer; },
				Receivers = new List<Customer>()
			};
		}
	}
}