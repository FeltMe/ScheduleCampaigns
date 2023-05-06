using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace MyApplicationName.Azure.Function
{
	public class CampaingCallSchedule
    {
		private readonly HttpClient _client;
		private readonly Options _options;
		private const bool RunOnStartup = true;

		public CampaingCallSchedule(IHttpClientFactory httpClientFactory, IOptions<Options> options)
        {
			_client = httpClientFactory.CreateClient();
			_options = options.Value;
		}

		[FunctionName("CampingCallScheduleAt10_05")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_05([TimerTrigger("0 5 10 * * *", RunOnStartup = RunOnStartup)] TimerInfo timer, ILogger log)
		{
			await ExecuteAsync("POST", _options.ApiUrl + "/api/Campaign/sendNotification", "application/json",
						$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}", log);
		}

		[FunctionName("CampingCallScheduleAt10_10")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_10([TimerTrigger("0 10 10 * * *", RunOnStartup = !RunOnStartup)] TimerInfo timer, ILogger log)
		{
			await ExecuteAsync("POST", _options.ApiUrl + "/api/sendNotification", "application/json",
						$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}", log);
		}

		[FunctionName("CampingCallScheduleAt10_15")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_15([TimerTrigger("0 15 10 * * *", RunOnStartup = !RunOnStartup)] TimerInfo timer, ILogger log)
		{
			await ExecuteAsync("POST", _options.ApiUrl + "/api/sendNotification", "application/json", 
			$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}", log);
		}

		private async Task ExecuteAsync(string method, string requestUrl, string contentType, string body, ILogger log)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

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
