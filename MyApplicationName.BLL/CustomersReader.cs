using CsvHelper;
using CsvHelper.Configuration;
using MyApplicationName.Models.Models;
using System.Globalization;

namespace MyApplicationName.BLL
{
	public class CustomersReader
	{
		private const string pathToFile = @"..\MyApplicationName.BLL\CustomerData\customers.csv";
		public async Task<IEnumerable<Customer>> GetCustomersAsync()
		{
			var csv = await File.ReadAllTextAsync(pathToFile);
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