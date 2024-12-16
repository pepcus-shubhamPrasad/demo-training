using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunction
{
    public class DemoShubham
    {
        private readonly ILogger<DemoShubham> _logger;

        public DemoShubham(ILogger<DemoShubham> logger)
        {
            _logger = logger;
        }

        [Function("DemoShubham")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
           
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string name = req.Query["name"]!;
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody)!;
            name = name ?? data?.Name!;
            return name != null  ? (ActionResult)new OkObjectResult($"Hello {name}") 
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
