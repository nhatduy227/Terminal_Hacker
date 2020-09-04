using System.Runtime.InteropServices;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game database
    string[] UchihaPassword = { "cow", "dog", "chin", "face","nom" };
    string[] GooglePassword = { "actors", "actress", "arrest", "artist", "please" };
    // Game State 
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

    // Initialization
    void Start()
    {
        ShowStartMenu("Nom");

    }
    // Function declarations 
    void ShowStartMenu(string name) 
    {
        // Clean up and change game state
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        // Greetings
        Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("What would you like to hack into ? \n");
        Terminal.WriteLine("Press 1 to hack into Uchiha");
        Terminal.WriteLine("Press 2 to hack into Google \n");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        // Show main menu
        if (input == "menu")
        {
            ShowStartMenu("Nom");
        }
        else if (currentScreen == Screen.MainMenu) 
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunGame(input);
        }
    }
    void RunMainMenu(string input) 
    {
        // Case 1
        if (input == "1")
        {
            level = 1;
            password = UchihaPassword[Random.Range(0, UchihaPassword.Length)];
            StartGame("Uchiha");
        }
        // Case 2
        else if (input == "2")
        {
            level = 2;
            password = GooglePassword[Random.Range(0, GooglePassword.Length)];
            StartGame("Google");
        }
        // Invalid Input
        else
        {
            Terminal.WriteLine("Invalid Input");
        }
    }
    void RunGame(string input) 
    {
        if (input == password)
        {
            DisplayWin();
        }
        else
        {
            Terminal.WriteLine("Wrong password. Please try again");
        }      
    }
    void StartGame(string levelName)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen to hack into " + levelName);
        Terminal.WriteLine("Please enter your password: ");
    }
    void DisplayWin() 
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowReward();
    }
    void ShowReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Uchiha's hidden sword");
                Terminal.WriteLine(@"
    />_______
[##[]________>
    \>
                ");
                Terminal.WriteLine("Type 'menu' to play again");
                break;
            case 2:
                Terminal.WriteLine("Google's humanoid");
                Terminal.WriteLine(@"
      \_/
     (* *)
    __)#(__
   ( )...( )(_)
   || |_| ||//
>==() | | ()/
    _(___)_
   [-]   [-]
                ");
                Terminal.WriteLine("Type 'menu' to play again");
                break;
        }
    }
}
