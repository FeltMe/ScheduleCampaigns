using HtmlAgilityPack;
using MyApplicationName.BLL.HTMLUtil;
using MyApplicationName.Models.Models;

namespace MyApplicationName.BLL.FactoryMethod
{
	public abstract class CampaignCreator
	{
		private HtmlToText _htmlToText = new HtmlToText();
		private const string pathToTemplate = @"..\MyApplicationName.BLL\Templates\";
		public abstract CampaignModel Create();

		public string GetTemplateText(string templateName)
		{
			return _htmlToText.Convert(pathToTemplate + templateName + ".html");
		}
	}
}
