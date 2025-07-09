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
        private string connectionString = $@"Data Source={AppDomain.CurrentDomain.BaseDirectory}TamagotchiDB.db;Version=3;";

        public void AddUser(string name, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string InsertNewUser = "INSERT INTO User (Username, Password, Piggybank) VALUES (@name, @password, @piggybank)";
                connection.Open();
                using (SQLiteCommand newUserCommand = new SQLiteCommand(InsertNewUser, connection)) {
                    newUserCommand.Parameters.AddWithValue("@name", name);
                    newUserCommand.Parameters.AddWithValue("@password", password);
                    newUserCommand.Parameters.AddWithValue("@piggybank", 200);

                    newUserCommand.ExecuteNonQuery();
                }
          
                connection.Close();

            }
        }

        public void AddPet(string name, string species)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string makeNewPet = "INSERT INTO PET (PetName, Species, Level, Hunger, Happiness) VALUES (@name, @species, @level, @hunger, @happiness)";
                connection.Open();
                using (SQLiteCommand newPetCommand = new SQLiteCommand(makeNewPet, connection))
                {
                    newPetCommand.Parameters.AddWithValue("@name", name);
                    newPetCommand.Parameters.AddWithValue("@species", species);
                    newPetCommand.Parameters.AddWithValue("@level", 0);
                    newPetCommand.Parameters.AddWithValue("@hunger", 100);
                    newPetCommand.Parameters.AddWithValue("@happiness", 100);
                    newPetCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public bool CheckValidLogin(string name, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string validateLogin = "SELECT * FROM User WHERE Username = @name AND Password = @password";
                connection.Open();
                using (SQLiteCommand loginCommand = new SQLiteCommand(validateLogin, connection))
                {
                    loginCommand.Parameters.AddWithValue("@name", name);
                    loginCommand.Parameters.AddWithValue("@password", password);
                    using (SQLiteDataReader reader = loginCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Login successful!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                            return false;
                        }
                    }
                }

            }
        }
    }
}
