using System.Collections.Generic;

namespace Todo.Services
{
    public class ServersProvider : IServersProvider
    {
        public ServersProvider()
        {
        }

        public List<string> GetEnvironments()
        {
            var environments = new List<string>();
            environments.Add("Debug");
            environments.Add("CI");
            environments.Add("Test");
            environments.Add("UAT");
            environments.Add("Live");
            return environments;
        }
    }
}
