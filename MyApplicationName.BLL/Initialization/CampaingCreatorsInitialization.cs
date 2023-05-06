using MyApplicationName.BLL.FactoryMethod.Creators;
using MyApplicationName.Models.Models;

namespace MyApplicationName.BLL.Initialization
{
	public class CampaingCreatorsInitialization
	{
		public IEnumerable<CampaignModel> GetAllCampaignModels()
		{
			return new List<CampaignModel>
			{
				new Campaign1Creator().Create(),
				new Campaign2Creator().Create(),
				new Campaign3Creator().Create(),
				new Campaign4Creator().Create(),
				new Campaign5Creator().Create()
			};
		}
	}
}
