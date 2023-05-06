<h1 align="center"/> This is a system to send schedule campaigns for the marketer.

<h5 align="left"/> Campaign combine:

<p>
 <ul>
  <li>Template</li>
  <li>Conditions on the list of customers. For example, all the males above 30 years. (for our exercise each campaign can handle one condition)</li>
  <li>Time to send the campaign.</li>
  <li>Priority</li>
</ul>
</p>

<h2 align="center"/> My Realisation

<h5 align="left"/> First of all I split all my Layers to next one:
<p>
<ul> 
  <li>MyApplicationName.Api</li>
  <li>MyApplicationName.Azure.Function</li>
  <li>MyApplicationName.BLL</li>
  <li>MyApplicationName.Models</li>
  <li>MyApplicationName.Sender.Organiser</li>
</ul>
</p>

<p>The main princepie is next: </p>
<p><b>Azure function</b> runed on the some cloud invoke the <b>Api Controller</b>, then I generate Campings and using  <b>Priority Queue</b>  
I "Send" my Templates<p/>

<p>Parse HTML using <a href="https://html-agility-pack.net/">HTMLAgilityPack</a></p>
<p>To run Azure function use <a href="https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite">Azurity</a></p>
<p>More about <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2?view=net-8.0">Priority Queue</a></p>
<p>Parse CSV file using <a href="https://github.com/JoshClose/CsvHelper">Csv Helper</a></p>

<h2 align="center"/> How to run
<h5 align="left">To run application select multiple project in Visual Studio</p>
<p><img src="https://user-images.githubusercontent.com/41016761/236642506-5e283ed4-f2da-40de-9d94-b3dd278c4611.png" alt="альтернативний текст"></p>
<p>Use Azurity</p>
<p>Set <b>private const bool RunOnStartup = true;</b> to run it with application start</p>
