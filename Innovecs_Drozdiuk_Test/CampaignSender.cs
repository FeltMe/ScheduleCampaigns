using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test
{
	public class CampaignSender
	{
		private const string fileName = @"..\Innovecs_Drozdiuk_Test\send.txt";
		public async Task SendCampingAsync(PriorityQueue<CampaignModel, int> priorityQueue)
		{
			using var streamWriter = new StreamWriter(fileName);
			while (priorityQueue.Count > 0)
			{
				var campaignModel = priorityQueue.Dequeue();
				await streamWriter.WriteLineAsync(campaignModel?.ToString() + "\n");
			}
		}
	}
}