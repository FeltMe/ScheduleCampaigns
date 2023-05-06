using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunction
{
    public class ApiCallsScheduler
    {
		[FunctionName("SendCampaingNotification")]
		[FixedDelayRetry(5, "00:01:00")]
		public async Task BirthdayCongratulations([TimerTrigger("0 0 10 * * *")] TimerInfo timer, ILogger logger)
		{
			await ExecuteAsync("GET", _options.NotificationsWebApi + "/api/employees/birthday-congratulations", null, null, logger);
		}
	}
}