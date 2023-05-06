using Innovecs_Drozdiuk_Test.Models;

namespace MyApplicationName.Sender.Organiser
{
	public class MessageSender
	{
		private const string fileName = @"..\Innovecs_Drozdiuk_Test\send.txt";

		/// <summary>
		/// In case when we write to file we have to wait till writing ends. 
		/// In real one case we don't need to wait and can use Fire And Forget
		/// </summary>
		/// <param name="priorityQueue"></param>
		/// <returns></returns>
		public async Task Send(PriorityQueue<CampaignModel, int> priorityQueue)
		{
			using var streamWriter = new StreamWriter(fileName);
			while (priorityQueue.Count > 0)
			{
				var campaignModel = priorityQueue.Dequeue();

				await Task.Delay(3000);
				await streamWriter.WriteLineAsync(campaignModel?.ToString() + "\n");
			}
		}
	}
}