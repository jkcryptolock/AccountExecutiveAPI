using System.IO;
using Newtonsoft.Json.Linq;

namespace AccountExecutiveAPI.Repositories
{
    public class UsersRepository
    {
        public JObject GetUsers()
        {
            JObject users = JObject.Parse(File.ReadAllText(@"Data/Users.json"));

            return users;
        }
    }
}