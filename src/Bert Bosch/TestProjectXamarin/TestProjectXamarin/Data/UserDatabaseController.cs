using SQLite;
using TestProjectXamarin.Models;
using Xamarin.Forms;

namespace TestProjectXamarin.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public User GetUser(string userName)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault(dbUser => dbUser.Username == userName);
            }
        }

        public void SaveUser(User user)
        {
            lock (locker)
            {
                User dbUser = database.Table<User>().FirstOrDefault(dbu => dbu.Username == user.Username);

                if (dbUser == null)
                {
                    dbUser = user;

                    database.Insert(dbUser);
                }
                else
                {
                    database.Update(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
