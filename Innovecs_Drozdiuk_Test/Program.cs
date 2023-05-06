using Innovecs_Drozdiuk_Test;
using Innovecs_Drozdiuk_Test.Initialization;
using Innovecs_Drozdiuk_Test.Models;

var sender = new CampaignSender();
var customersReader = new CustomersReader();
var customers = await customersReader.GetCustomersAsync();

var initializator = new CampaingCreatorsInitialization();
var models = initializator.GetAllCampaignModels();

var priorityQueue = new PriorityQueue<CampaignModel, int>();

foreach (var customer in customers)
{
	var handleModel = models.FirstOrDefault(x => x.Predicate(customer));
	handleModel?.Receivers.Append(customer);
}

foreach (var item in models)
{
	priorityQueue.Enqueue(item, item.Priority);
}

while(priorityQueue.Count > 0)
{
	var campaignModel = priorityQueue.Dequeue();
	await sender.SendCampingAsync(campaignModel, CancellationToken.None);
}