using System.IO;
using Newtonsoft.Json.Linq;

namespace AccountExecutiveAPI.Repositories
{
    public class CompaniesRepository
    {
        
        public JObject GetCompanies()
        {
            JObject companies = JObject.Parse(File.ReadAllText(@"Data/Companies.json"));

            return companies;
        }
        
    }
}