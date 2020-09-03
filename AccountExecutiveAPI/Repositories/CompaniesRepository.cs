using System.IO;
using Newtonsoft.Json.Linq;

namespace AccountExecutiveAPI.Repositories
{
    public class CompaniesRepository
    {
        public static JObject GetCompanies()
        {
            var companies = JObject.Parse(File.ReadAllText(@"Data/Companies.json"));

            return companies;
        }
        
    }
}