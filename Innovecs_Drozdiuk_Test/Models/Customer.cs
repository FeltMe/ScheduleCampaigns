namespace Innovecs_Drozdiuk_Test.Models
{
	public class Customer
	{
		public int CUSTOMER_ID { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public string City { get; set; }
		public decimal Deposit { get; set; }
		public bool NewCustomer { get; set; }

		public Customer(){}

		public Customer(int cUSTOMER_ID, int age, string gender, string city, decimal deposit, bool newCustomer)
		{
			CUSTOMER_ID = cUSTOMER_ID;
			Age = age;
			Gender = gender;
			City = city;
			Deposit = deposit;
			NewCustomer = newCustomer;
		}

		public Customer(Customer customer) : 
		this(customer.CUSTOMER_ID, customer.Age, customer.Gender, customer.City, customer.Deposit, customer.NewCustomer){}
	}
}
