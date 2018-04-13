using SQLite;
using System.IO;
using TestProjectXamarin.Data;
using TestProjectXamarin.UWP.Data;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_UWP))]
namespace TestProjectXamarin.UWP.Data
{
    public class SQLite_UWP : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFileName = "TestDB.db3";

            string documentPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            string path = Path.Combine(documentPath, sqliteFileName);

            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}