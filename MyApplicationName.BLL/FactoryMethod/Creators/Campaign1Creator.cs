using MyApplicationName.Models.Models;

namespace MyApplicationName.BLL.FactoryMethod.Creators
{
	public class Campaign1Creator : CampaignCreator
	{
		private const string maleGender = "Male";
		private const string templateName = "Template A";
		private const int sendHour = 10;
		private const int sendMinute = 15;
		private const int campingPriority = 1;

		public override CampaignModel Create()
		{
			var templateModel = new TemplateModel(templateName);
			templateModel.TemplateString = base.GetTemplateText(templateName);

			return new CampaignModel()
			{
				Priority = campingPriority,
				TemplateModel = templateModel,
				Time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, sendHour, sendMinute, 0),
				Predicate = delegate (Customer customer) { return customer.Gender == maleGender; },
				Receivers = new List<Customer>()
			};
		}
	}
}
