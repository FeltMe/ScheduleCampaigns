using CsvHelper;
using CsvHelper.Configuration;
using Innovecs_Drozdiuk_Test.Models;
using System.Globalization;

namespace Innovecs_Drozdiuk_Test
{
	public class CustomersReader
	{
		private const string pathToFile = @"..\Innovecs_Drozdiuk_Test\CustomerData\customers.csv";
		public async Task<IEnumerable<Customer>> GetCustomersAsync()
		{
			var csv = await System.IO.File.ReadAllTextAsync(pathToFile);
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