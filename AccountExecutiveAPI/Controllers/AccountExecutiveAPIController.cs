﻿using System.Collections.Generic;
using AccountExecutiveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountExecutiveAPI.Repositories;
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("companies")]
        public string GetCompaniesJson()
        {
            var companies = new CompaniesRepository();

            string output = JsonConvert.SerializeObject(companies.GetCompanies());

            return output;
        }
        
        [HttpGet]
        [Route("users")]
        public string GetUsersJson()
        {
            var users = new UsersRepository();

            string output = JsonConvert.SerializeObject(users.GetUsers());

            return output;
        }

        [HttpPost]
        [Route("companies")]
        public string GetAeCompaniesJson([FromBody] string accountExecutive)
        {
            var companies = new CompaniesRepository();
            dynamic response = companies.GetCompanies();
            List<CompanyData> aeCompanies = new List<CompanyData>();

            foreach (var company in response.companies)
            {
                if (company.accountExecutive == accountExecutive)
                {
                    var listItem = new CompanyData();
                    listItem.Company = company.company;
                    listItem.StreetAddress = company.streetAddress;
                    listItem.City = company.city;
                    listItem.Id = company.id;
                    listItem.Phone = company.phone;
                    listItem.State = company.state;
                    listItem.ZipCode = company.zipCode;
                    listItem.AccountExecutive = company.accountExecutive;
                    listItem.ActiveContracts = company.activeContracts;
                    listItem.ActiveTickets = company.activeTickets;

                    aeCompanies.Add(listItem);
                }
            }

            string output = JsonConvert.SerializeObject(aeCompanies);

            return output;
        }
    }
}