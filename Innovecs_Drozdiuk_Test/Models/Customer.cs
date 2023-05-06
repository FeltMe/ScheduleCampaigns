﻿namespace Innovecs_Drozdiuk_Test.Models
{
	public class Customer
	{
		public int CUSTOMER_ID { get; set; }
		public int Age { get; set; }
		public string? Gender { get; set; }
		public string? City { get; set; }
		public decimal Deposit { get; set; }
		public bool NewCustomer { get; set; }
		public bool IsSended { get; set; } = false;
	}
}
