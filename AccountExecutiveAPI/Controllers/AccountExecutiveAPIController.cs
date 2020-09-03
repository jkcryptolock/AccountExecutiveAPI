using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountExecutiveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountExecutiveAPI.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace AccountExecutiveAPI.Controllers
{
    [ApiController]
    [Route("api/accountexecutive")]
    public class AccountExecutiveAPIController : ControllerBase
    {
        private readonly ILogger<AccountExecutiveAPIController> _logger;

        public AccountExecutiveAPIController(ILogger<AccountExecutiveAPIController> logger)
        {
            _logger = logger;
        }

        private readonly Random _rnd = new Random();

        private void SetTimeout()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(_rnd.Next(2000, 4000));
            });
            t.Wait();
        }

        [HttpGet]
        [Route("companies")]
        public string GetCompaniesJson()
        {
            SetTimeout();
            
            var dataAccess = new CompaniesRepository();
            dynamic companies = CompaniesRepository.GetCompanies();
            string output = JsonConvert.SerializeObject(companies.companies);

            return output;
        }
        
        [HttpGet]
        [Route("users")]
        public string GetUsersJson()
        {
            SetTimeout();

            var dataAccess = new UsersRepository();
            dynamic users = UsersRepository.GetUsers();
            string output = JsonConvert.SerializeObject(users.users);

            return output;
        }

        [HttpPost]
        [Route("companies")]
        public string GetAeCompaniesJson([FromBody] AccountExecutiveData accountExecutive)
        {
            SetTimeout();

            var dataAccess = new CompaniesRepository();
            dynamic response = CompaniesRepository.GetCompanies();
            var aeCompanies = new List<CompanyData>();

            foreach (JObject companyRecord in response.companies)
            {
                var company = companyRecord.ToObject<CompanyData>();

                if (company == null) continue;
                
                var companyAe = company.AccountExecutive;
                
                if (string.Equals(companyAe, accountExecutive.AccountExecutive, StringComparison.CurrentCultureIgnoreCase))
                {
                    aeCompanies.Add(company);
                }
            }

            var output = JsonConvert.SerializeObject(
                aeCompanies,
                new JsonSerializerSettings 
                { 
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return output;
        }
    }
}