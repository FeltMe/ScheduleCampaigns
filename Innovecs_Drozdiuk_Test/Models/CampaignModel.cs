namespace Innovecs_Drozdiuk_Test.Models
{
	public class CampaignModel
	{
		public string? TemplateName { get; set; }
		public DateTime Time { get; set; }
		public int Priority { get; set; }
		public Predicate<CustomerSendingModel> Predicate { get; set; }
		public List<CustomerSendingModel> Receivers { get; set; }
		public override string ToString()
		{
			return $"Template {TemplateName}, sends in {Time}, to next customers: {GetCustomersNames(Receivers)}";
		}

		private string GetCustomersNames(IEnumerable<CustomerSendingModel> customers)
		{
			return customers.Any() && customers.Any() ? string.Join(",", customers.Select(x=> $"{x.CUSTOMER_ID} {x.Gender} {x.Deposit}")) : "None";
		}
	}
}