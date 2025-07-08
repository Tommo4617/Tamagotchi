// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.Data.SQLite;
using Tamagotchi_project;

//string connectionString = "Data Source=TamagotchiDB.db;Version=3;";
//using (SQLiteConnection connection = new SQLiteConnection(connectionString))
//{
//    connection.Open();
//    Console.WriteLine("connection opened successfully.");
//    CreateTable(connection);
//    // Execute queries here

//}

Console.WriteLine("Welcome to Tamagotchi! \n1.Login \n2.Sign up \n3.Close");
int selection = int.Parse(Console.ReadLine());
switch (selection) {
    case 1:
        Console.WriteLine("Logging in...");
        break;

    case 2:
        Console.WriteLine("Please enter a username:");
        string username = Console.ReadLine();
        Console.WriteLine("Please enter a password:");
        string password = Console.ReadLine();
        AccessDBData access = new AccessDBData();
        access.AddUser(username, password);
        break;

    case 3:
        Console.WriteLine("Closing the application...");
        Environment.Exit(0);
        break;
}

static void CreateTable(SQLiteConnection connection)
{
    string tableCmd = "CREATE TABLE IF NOT EXISTS User (UserID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Password TEXT, Piggybank INTEGER)";
    using var cmd = new SQLiteCommand(tableCmd, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Table created (if not exists).");
}

static void InsertData(SQLiteConnection connection, string name)
{
    string insertCmd = "INSERT INTO User (Username), (Password), (Piggybank) VALUES (@name), (@Password), (@Piggybank)";
    using var cmd = new SQLiteCommand(insertCmd, connection);
    cmd.Parameters.AddWithValue("@name", name);
    cmd.ExecuteNonQuery();
    Console.WriteLine($"Inserted: {name}");
}

static void LoginSequence()
{

}

static void SignUpSequence()
{

}


    


