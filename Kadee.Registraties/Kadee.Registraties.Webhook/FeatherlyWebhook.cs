using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Kadee.Registraties.Webhook
{
    public class FeatherlyWebhook
    {
        private readonly ILogger _logger;

        public FeatherlyWebhook(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FeatherlyWebhook>();
        }

        [Function("FeatherlyWebhook-newRegistration")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welkom bij de Kadee Registratie webhook!");

            return response;
        }
    }
}
