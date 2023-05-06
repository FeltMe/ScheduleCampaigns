using Innovecs_Drozdiuk_Test;
using Innovecs_Drozdiuk_Test.Initialization;
using Innovecs_Drozdiuk_Test.Models;

const string fileName = "../../../send.txt";

var sender = new CampaignSender();
var customersReader = new CustomersReader();
var customers = await customersReader.GetCustomersAsync();

var initializator = new CampaingCreatorsInitialization();
var models = initializator.GetAllCampaignModels();

var priorityQueue = new PriorityQueue<CampaignModel, int>();

foreach (var customer in customers)
{
	var handleModel = models.FirstOrDefault(x => x.Predicate(customer));
	handleModel?.Receivers.Add(customer);
}

foreach (var item in models)
{
	priorityQueue.Enqueue(item, item.Priority);
}

using var streamWriter = new StreamWriter(fileName);
while (priorityQueue.Count > 0)
{
	var campaignModel = priorityQueue.Dequeue();
	await sender.SendCampingAsync(campaignModel, streamWriter);
}

Console.WriteLine("End");