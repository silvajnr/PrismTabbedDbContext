using BlankApp1.Services;
using System.IO;

namespace BlankApp1.iOS
{
    public class SQliteService : ISQLite
    {
        public string GetDbUrl()
        {
            var libPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..", "Library");
            if (!Directory.Exists(libPath))
            {
                Directory.CreateDirectory(libPath);
            }

            return Path.Combine(libPath, "database.sqlite");
        }
    }
}