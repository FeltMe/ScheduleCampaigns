﻿using MyApplicationName.BLL.FactoryMethod;
using MyApplicationName.Models.Models;

namespace MyApplicationName.BLL.FactoryMethod.Creators
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
			var templateModel = new TemplateModel(templateName);
			templateModel.TemplateString = base.GetTemplateText(templateName);
			return new CampaignModel()
			{
				Priority = campingPriority,
				TemplateModel = templateModel,
				Time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, sendHour, sendMinute, 0),
				Predicate = delegate (Customer customer) { return customer.Deposit > depositeMoreThan; },
				Receivers = new List<Customer>()
			};
		}
	}
}
