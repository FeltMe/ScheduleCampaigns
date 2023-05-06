namespace Innovecs_Drozdiuk_Test.Models
{
	public  class CustomerSendingModel : Customer
	{
		public bool IsSended { get; set; } = false;

		public CustomerSendingModel(Customer customer) : base(customer){}
	}
}
