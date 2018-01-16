using System.Collections.Generic;

namespace Todo.Services
{
    public interface IServersProvider
    {
        List<string> GetEnvironments();

    }
}
