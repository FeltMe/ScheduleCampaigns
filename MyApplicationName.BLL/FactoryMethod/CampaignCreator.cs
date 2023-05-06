using MyApplicationName.Models.Models;

namespace MyApplicationName.BLL.FactoryMethod
{
	public abstract class CampaignCreator
	{
		public abstract CampaignModel Create();
	}
}
