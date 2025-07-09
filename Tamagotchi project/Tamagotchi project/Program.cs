// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.Data.SQLite;
using Tamagotchi_project;

AccessDBData access = new AccessDBData();
Console.WriteLine("Welcome to Tamagotchi! \n1.Login \n2.Sign up \n3.Close");
int selection;
while(!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 3)
{
    Console.WriteLine("Please enter a valid option (1, 2, or 3):");
}
switch (selection) {
    case 1:
        if (Login())
        {
            int mainMenuSelection = inGameMenuSelection();
            switch (mainMenuSelection)
            {
                case 1:
                    break;

                case 2:
                    createNewPet();
                    break;

                case 3:
                    break;

            }
        }
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

static bool Login()
{
    AccessDBData access = new AccessDBData();
    Console.WriteLine("Please enter your username:");
    string username1 = Console.ReadLine();
    Console.WriteLine("Please enter your password:");
    string password1 = Console.ReadLine();
    bool success =access.CheckValidLogin(username1, password1);
    return success;
}

static int inGameMenuSelection()
{
    Console.WriteLine("Welcome to Tamagotchi! \n What would you like to do? \n 1. Find a current pet \n 2. Create a new pet \n 3. Go back ");
    int selection;
    while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 3)
    {
        Console.WriteLine("Please enter a valid option (1, 2, or 3):");
    }
    return selection;
}

void createNewPet()
{
    Console.WriteLine("What pet would you like to create? \n 1. Dog \n 2. Cat \n 3. Rabbit");
    int selection;
    while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 3)
    {
        Console.WriteLine("Please enter a valid option (1, 2, or 3):");
    }
    Console.WriteLine("Please name your pet (You will be able to change this later):");
    string petName = Console.ReadLine();
    switch (selection)
    {
        case 1:
            Console.WriteLine($"You have now got a new dog ({petName})");
            break;
        case 2:
            Console.WriteLine($"You have now got a new cat ({petName})");
            Pet newPet = new Cat();
            AccessDBData access = new AccessDBData();
            access.AddPet(petName, "cat");

            break;
        case 3:
            Console.WriteLine($"You have now got a new rabbit ({petName})");
            break;

    }
}

