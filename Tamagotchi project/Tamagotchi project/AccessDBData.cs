using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Tamagotchi_project
{
    internal class AccessDBData
    {
        private string connectionString = "Data Source=TamagotchiDB.db;Version=3;";
        public void AddUser(string name, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string InsertNewUser = "INSERT INTO User (Username, Password, Piggybank) VALUES (@name, @password, @piggybank)";
                connection.Open();
                Console.WriteLine("COnnection made!");
                using (SQLiteCommand newUserCommand = new SQLiteCommand(InsertNewUser, connection)) {
                    newUserCommand.Parameters.AddWithValue("@name", name);
                    newUserCommand.Parameters.AddWithValue("@password", password);
                    newUserCommand.Parameters.AddWithValue("@piggybank", 200);

                    newUserCommand.ExecuteNonQuery();
                }
          
                connection.Close();

            }
        }
    }
}
