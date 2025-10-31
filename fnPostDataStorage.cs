using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.WebJobs.Extensions.Logging;
using Microsoft.Azure.webJobs.Extensions.Http;
using Newtonsoft.json;

namespace fnPostDataStorage
{
    public static class Function1
    {
        [FunctionName("Function1")]

        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Iniciando a validação");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeseralizeObject(requestBody);
            if (data == null)
            {
                return new BadRequestObjectResult("Por favor, informe o cpf");
            }
            string cpf = data?.cpf;

            return new OkObjectResult(responseMessage);
        }
        
        

    }

}