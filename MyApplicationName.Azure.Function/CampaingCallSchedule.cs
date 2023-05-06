using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MyApplicationName.Azure.Function
{
    public class CampaingCallSchedule
    {
		private readonly HttpClient _client;
		private readonly Options options;

        public CampaingCallSchedule(IHttpClientFactory httpClientFactory)
        {
			_client = httpClientFactory.CreateClient();
			options = new Options();
		}

		[FunctionName("CampingCallScheduleAt10_05")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_05([TimerTrigger("0 0 10 * * *")] TimerInfo timer, ILogger logger)
		{
			await ExecuteAsync("POST", options.Url + "/api/sendNotification", "application/json",
						$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}", logger);
		}

		[FunctionName("CampingCallScheduleAt10_10")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_10([TimerTrigger("0 0 10 * * *")] TimerInfo timer, ILogger logger)
		{
			await ExecuteAsync("POST", options.Url + "/api/sendNotification", "application/json",
						$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}", logger);
		}

		[FunctionName("CampingCallScheduleAt10_15")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_15([TimerTrigger("0 0 10 * * *")] TimerInfo timer, ILogger logger)
		{
			await ExecuteAsync("POST", options.Url + "/api/sendNotification", "application/json", 
			$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}", logger);
		}

		private async Task ExecuteAsync(string method, string requestUrl, string contentType, string body, ILogger log)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			log.LogInformation($"Begin execution of {method} request to {requestUrl}");

			var message = new HttpRequestMessage(new HttpMethod(method), requestUrl);
			if (!string.IsNullOrWhiteSpace(body))
			{
				message.Content = new StringContent(body, Encoding.UTF8, contentType);
			}

			try
			{
				using var response = await _client.SendAsync(message);
				if (response.IsSuccessStatusCode)
				{
					log.Log(LogLevel.Information, $"Execution end of {method} request to {requestUrl} - {(int)response.StatusCode}, elapsed {stopWatch.Elapsed}");
				}
				else
				{
					log.Log(LogLevel.Error, $"Unsuccessful execution of {method} request to {requestUrl} - {(int)response.StatusCode}, elapsed {stopWatch.Elapsed}");
				}
			}
			catch (Exception exc)
			{
				log.LogError(exc, $"Exception during execution of {method} request to {requestUrl}, elapsed {stopWatch.Elapsed}");
			}
		}

	}
}