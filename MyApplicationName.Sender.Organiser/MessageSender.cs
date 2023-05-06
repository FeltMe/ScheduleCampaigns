using MyApplicationName.Models.Models;

namespace MyApplicationName.Sender.Organiser
{
	public class MessageSender
	{
		private const string fileName = @"..\MyApplicationName.BLL\send.txt";
		public async Task Send(PriorityQueue<CampaignModel, int> priorityQueue)
		{
			using var streamWriter = new StreamWriter(fileName);
			while (priorityQueue.Count > 0)
			{
				var campaignModel = priorityQueue.Dequeue();
				await streamWriter.WriteLineAsync(campaignModel?.GetPlainText());
			}
		}
	}
}