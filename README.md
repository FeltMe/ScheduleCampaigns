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

<p>The main princepie is next: <p/>
<p><b>Azure function</b> runed on the some cloud invoke the <b>Api Controller</b>, then I generate Campings and using  <b>Priority Queue</b>  
I "Send" my Templates<p/>

Parse HTML using HTMLAgilityPack
To run Azure function use <a Azurity href="https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite"/>
