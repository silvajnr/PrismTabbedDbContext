using BlankApp1.DataStores;
using BlankApp1.Services;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    public class Class1
    {
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                Debug.WriteLine(Directory.GetCurrentDirectory() + @"\Config.db");
                var url = new DataStoreDb();
                return new ApplicationDbContext(url);
            }
        }

        public class DataStoreDb : ISQLite
        {
            public string GetDbUrl()
            {
                return Directory.GetCurrentDirectory() + @"\Config.db";
            }
        }
    }
}
