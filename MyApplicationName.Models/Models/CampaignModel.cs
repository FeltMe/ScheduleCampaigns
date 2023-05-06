namespace MyApplicationName.Models.Models
{
	public class CampaignModel
	{
		public DateTime Time { get; set; }
		public int Priority { get; set; }
		public Predicate<Customer> Predicate { get; set; }
		public List<Customer> Receivers { get; set; }
		public TemplateModel TemplateModel { get; set; }

		public string GetPlainText()
		{
			return TemplateModel.TemplateString + "\n" +
			$"Sends in {DateTime.UtcNow.ToShortTimeString()} as {Time.ToShortTimeString()}, to next customers id: " +
			$"{GetCustomersNames(Receivers)}";
		}

		private string GetCustomersNames(IEnumerable<Customer> customers)
		{
			return customers.Any() && customers.Any() ? string.Join(",", customers.Select(x => $"{x.CUSTOMER_ID}")) : "None";
		}
	}
}