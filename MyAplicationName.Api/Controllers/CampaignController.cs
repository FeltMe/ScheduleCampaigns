﻿using Microsoft.AspNetCore.Mvc;
using MyApplicationName.Api.Interfaces;
using MyApplicationName.Models.Models;

namespace MyApplicationName.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CampaignController : ControllerBase
	{
		private readonly ILogger<CampaignController> _logger;
		private readonly ICampaignService _campaignService;

		public CampaignController(
			ILogger<CampaignController> logger,
			ICampaignService campaignService
		)
		{
			_logger = logger;
			_campaignService = campaignService;
		}

		[HttpPost("sendNotification")]
        public async Task SendCampingNotification(TimeModel model)
		{
			_logger.LogInformation("Controller CampaignController start sendNotification request");
			await _campaignService.SendNotification(model);
        }
    }
}
