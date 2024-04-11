using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Kadee.Registraties.Webhook
{
    public class KadeeWebhook
    {
        private readonly ILogger _logger;

        public KadeeWebhook(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<KadeeWebhook>();
        }

        [Function("KadeeWebhook")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
