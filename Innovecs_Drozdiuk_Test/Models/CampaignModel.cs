﻿namespace Innovecs_Drozdiuk_Test.Models
{
	public class CampaignModel
	{
		public string? TemplateName { get; set; }
		public DateTime Time { get; set; }
		public int Priority { get; set; }
		public Predicate<Customer> Predicate { get; set; }
		public IEnumerable<Customer> Receivers { get; set; }
		public override string ToString()
		{
			return $"Template {TemplateName}, sends in {Time}, to next customers: {GetCustomersNames(Receivers)}";
		}

		private string GetCustomersNames(IEnumerable<Customer> customers)
		{
			return customers.Any() && customers.Any() ? string.Join(",", customers) : "None";
		}
	}
}