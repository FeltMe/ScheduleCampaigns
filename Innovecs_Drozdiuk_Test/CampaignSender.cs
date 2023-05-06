using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test
{
	public class CampaignSender
	{
		public async Task SendCampingAsync(CampaignModel campaignModel, StreamWriter streamWriter)
		{
			await streamWriter.WriteLineAsync(campaignModel?.ToString() + "\n");
		}
	}
}