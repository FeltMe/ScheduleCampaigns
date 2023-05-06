using MyApplicationName.Models.Models;
using MyApplicationName.Sender.Organiser;

namespace MyApplicationName.BLL
{
	public class CampaignSender
	{
		private readonly MessageSender messageSender;
		public CampaignSender()
		{
			messageSender = new MessageSender();
		}
		public async Task SendCampingAsync(PriorityQueue<CampaignModel, int> priorityQueue)
		{
			await messageSender.Send(priorityQueue);
		}
	}
}