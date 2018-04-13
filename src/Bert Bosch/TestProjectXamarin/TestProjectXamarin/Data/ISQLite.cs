using SQLite;

namespace TestProjectXamarin.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
