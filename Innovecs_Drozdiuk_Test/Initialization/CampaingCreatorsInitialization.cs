using Innovecs_Drozdiuk_Test.FactoryMethod;
using Innovecs_Drozdiuk_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovecs_Drozdiuk_Test.Initialization
{
	public class CampaingCreatorsInitialization
	{
		public IEnumerable<CampaignModel> GetAllCampaignModels()
		{
			return new List<CampaignModel>
			{
				new Campaign1Creator().Create(),
				new Campaign1Creator().Create(),
				new Campaign1Creator().Create(),
				new Campaign1Creator().Create(),
				new Campaign1Creator().Create()
			};
		}
	}
}
