using BlankApp1.Services;
using System;

namespace BlankApp1.DataStores
{
    public class GenerateDbContext : IGenerateDbContext
    {
        readonly ISQLite _sqlite;
        readonly string _instance = Guid.NewGuid().ToString();
        public string Instace
        {
            get => _instance;
        }

        public GenerateDbContext(ISQLite sqlite)
        {
            $"GenerateDbContext check instance {_instance}".ConsoleText();
            _sqlite = sqlite;
        }


        public IApplicationDbContext GenerateNewContext()
        {

            IApplicationDbContext dbContext = new ApplicationDbContext(_sqlite);
            $"GenerateDbContext GenerateNewContext() dbContext:{dbContext.Instace} instance {_instance}".ConsoleText();
            return dbContext;
        }

        public void Dispose()
        {
            $"GenerateDbContext Dispose() instance {_instance}".ConsoleText();
        }

    }
}
