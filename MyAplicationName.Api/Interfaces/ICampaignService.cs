using MyApplicationName.Models.Models;

namespace MyApplicationName.Api.Interfaces
{
	public interface ICampaignService
	{
		public Task SendNotification(TimeModel timeModel);
	}
}
