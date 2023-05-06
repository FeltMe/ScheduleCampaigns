using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test
{
	public class CampaignSender
	{
		private const string fileName = "send.txt";
		public async Task SendCampingAsync(CampaignModel campaignModel, CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				using var streamWriter = new StreamWriter(fileName);
				await streamWriter.WriteLineAsync(campaignModel?.ToString());
			}
			setReceiversToFalse(campaignModel?.Receivers); //todo handle null
		}

		private void setReceiversToFalse(IEnumerable<Customer> customerModels)
		{
			foreach (var customerSendingModel in customerModels)
			{
				customerSendingModel.IsSended = true;
			}
		}
	}
}