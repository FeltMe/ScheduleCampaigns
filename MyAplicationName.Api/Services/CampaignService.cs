using MyApplicationName.Api.Interfaces;
using MyApplicationName.Models.Models;
using MyApplicationName.BLL;
using MyApplicationName.BLL.Initialization;

namespace MyApplicationName.Api.Services
{
	public class CampaignService : ICampaignService
	{
		private readonly CampaignSender campaignSender;
		private readonly CustomersReader customersReader;
		private readonly CampaingCreatorsInitialization campaingCreators;

		public CampaignService()
		{
			campaignSender = new CampaignSender();
			customersReader = new CustomersReader();
			campaingCreators = new CampaingCreatorsInitialization();
		}

		#region public Methods
		public async Task SendNotification()
		{
			var campaignModels = campaingCreators.GetAllCampaignModels();
			var customers = await customersReader.GetCustomersAsync();

			RecipientsDetermination(customers, campaignModels);
			await SendCampingAsync(campaignModels);
		}
		#endregion

		#region Private Methods

		private void RecipientsDetermination(IEnumerable<Customer> customers, IEnumerable<CampaignModel> campaignModels)
		{
			foreach (var customer in customers)
			{
				var handleModel = campaignModels.FirstOrDefault(x => x.Predicate(customer));
				handleModel?.Receivers.Add(customer);
			}
		}

		private async Task SendCampingAsync(IEnumerable<CampaignModel> campaignModels)
		{
			var priorityQueue = new PriorityQueue<CampaignModel, int>();
			foreach (var item in campaignModels)
			{
				priorityQueue.Enqueue(item, item.Priority);
			}
			
			await campaignSender.SendCampingAsync(priorityQueue);
		}

		#endregion
	}
}