// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.Data.SQLite;
using Tamagotchi_project;

AccessDBData access = new AccessDBData();
Console.WriteLine("Welcome to Tamagotchi! \n1.Login \n2.Sign up \n3.Close");
int selection = int.Parse(Console.ReadLine());
switch (selection) {
    case 1:
        Console.WriteLine("Please enter your username:");
        string username1 = Console.ReadLine();
        Console.WriteLine("Please enter your password:");
        string password1 = Console.ReadLine();
        access.CheckValidLogin(username1, password1);
        break;

    case 2:
        Console.WriteLine("Please enter a username:");
        string username = Console.ReadLine();
        Console.WriteLine("Please enter a password:");
        string password = Console.ReadLine();
        
        access.AddUser(username, password);
        break;

    case 3:
        Console.WriteLine("Closing the application...");
        Environment.Exit(0);
        break;
}




    


