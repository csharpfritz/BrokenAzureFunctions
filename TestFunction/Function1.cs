using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure;
using System.ComponentModel;

namespace TestFunction
{
	public static class Function1
	{
		[FunctionName("Function1")]
		public static async Task<IActionResult> Run(
				[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
				ILogger log)
		{
			log.LogInformation("C# HTTP trigger function processed a request.");

			string setting1Value = CloudConfigurationManager.GetSetting("Setting1");


			return (ActionResult)new OkObjectResult($"Setting1's value is: {setting1Value}");
		}
	}
}
