using CsvHelper;
using CsvHelper.Configuration;
using Innovecs_Drozdiuk_Test.Models;
using System.Globalization;

namespace Innovecs_Drozdiuk_Test
{
	public class CustomersReader
	{
		public async Task<IEnumerable<Customer>> GetCustomersAsync()
		{
			var csv = await System.IO.File.ReadAllTextAsync(@"..\..\..\\CustomerData\customers.csv");
			var textReader = new StringReader(csv);
			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				NewLine = Environment.NewLine,
			};
			var csvr = new CsvReader(textReader, config);
			var records = csvr.GetRecords<Customer>();

			return records.ToList();
		}
	}
}