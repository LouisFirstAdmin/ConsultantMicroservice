using System;
using System.IO;
using System.Threading.Tasks;
using ConsultantData.Model;
using ConsultantService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ninject;

namespace ConsultantFunction
{
    public class GetConsultants
    {
        private readonly IConsultantRepository repository;

        public GetConsultants(IConsultantRepository consultantRepository)
        {
            repository = consultantRepository ?? throw new ArgumentNullException(nameof(consultantRepository));
        }

        [FunctionName("GetConsultants")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var someData = repository.GetConsultants();

            return new OkObjectResult(someData);
            
        }
    }
}

