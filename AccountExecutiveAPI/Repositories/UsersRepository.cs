using System.IO;
using Newtonsoft.Json.Linq;

namespace AccountExecutiveAPI.Repositories
{
    public class UsersRepository
    {
        public static JObject GetUsers()
        {
            var users = JObject.Parse(File.ReadAllText(@"Data/Users.json"));

            return users;
        }
    }
}