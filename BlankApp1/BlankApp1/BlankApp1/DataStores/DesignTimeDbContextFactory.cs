using BlankApp1.Services;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BlankApp1.DataStores
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
