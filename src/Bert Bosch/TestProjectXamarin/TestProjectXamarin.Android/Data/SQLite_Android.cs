using SQLite;
using System.IO;
using TestProjectXamarin.Data;
using TestProjectXamarin.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace TestProjectXamarin.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFileName = "TestDB.db3";

            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string path = Path.Combine(documentPath, sqliteFileName);

            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}