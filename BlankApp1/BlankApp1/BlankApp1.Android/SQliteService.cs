using BlankApp1.Services;
using System.IO;

namespace BlankApp1.Droid
{
    class SQliteService : ISQLite
    {

        public string GetDbUrl()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "database.sqlite");
        }
    }
}