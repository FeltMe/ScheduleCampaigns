using Innovecs_Drozdiuk_Test.Models;
using MyApplicationName.Sender.Organiser;

namespace Innovecs_Drozdiuk_Test
{
	public class CampaignSender
	{
		private readonly MessageSender messageSender;
		public CampaignSender() { 
			messageSender = new MessageSender();
		}
		public async Task SendCampingAsync(PriorityQueue<CampaignModel, int> priorityQueue)
		{
			await messageSender.Send(priorityQueue);
		}
	}
}