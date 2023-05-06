namespace MyApplicationName.Models.Models
{
	public class TemplateModel
	{
		public string TemplateName { get; set; }
		public string TemplateString { get; set; }

		public TemplateModel(string templateName)
		{
			this.TemplateName = templateName;
		}
	}
}
