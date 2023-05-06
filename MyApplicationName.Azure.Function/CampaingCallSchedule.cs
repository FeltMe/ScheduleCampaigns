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
		public async Task CampingCallScheduleAt10_05([TimerTrigger("0 5 10 * * *", RunOnStartup = true)] TimerInfo timer)
		{
			await ExecuteAsync("POST", options.Url + "/api/sendNotification", "application/json",
						$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}");
		}

		[FunctionName("CampingCallScheduleAt10_10")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_10([TimerTrigger("0 10 10 * * *", RunOnStartup = true)] TimerInfo timer)
		{
			await ExecuteAsync("POST", options.Url + "/api/sendNotification", "application/json",
						$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}");
		}

		[FunctionName("CampingCallScheduleAt10_15")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task CampingCallScheduleAt10_15([TimerTrigger("0 15 10 * * *", RunOnStartup = true)] TimerInfo timer)
		{
			await ExecuteAsync("POST", options.Url + "/api/sendNotification", "application/json", 
			$"{{ \"Hours\": \"{10}\", \"Minutes\" : \"{15}\" }}");
		}

		private async Task ExecuteAsync(string method, string requestUrl, string contentType, string body)
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
			}
			finally
			{
				stopWatch.Stop();
			}
		}

	}
}
