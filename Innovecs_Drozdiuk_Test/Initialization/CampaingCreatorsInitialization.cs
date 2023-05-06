using Innovecs_Drozdiuk_Test.FactoryMethod.Creators;
using Innovecs_Drozdiuk_Test.Models;

namespace Innovecs_Drozdiuk_Test.Initialization
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
