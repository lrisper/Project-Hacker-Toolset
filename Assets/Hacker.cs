using UnityEngine;

public class Hacker : MonoBehaviour
{
	int level;
	string password;
	const string menuHint = "You may type menu at any time";
	string[] localStorePasswords = { "candle", "shelf", "worker", "food", "cangoods" };
	string[] policeRecordPasswords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
	string[] localBankPasswords = { "money", "million", "billion", "trillion", "dollars" };

	enum Screen
	{
		MainMenu,
		password,
		win

	}

	Screen currentScreen;

	// Use this for initialization
	void Start ()
	{
		ShowMainMenu();
	}

	void ShowMainMenu ()
	{
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Welcome to the Hackers toolset");
		Terminal.WriteLine("");
		Terminal.WriteLine("What would you like to hack into?");
		Terminal.WriteLine("");
		Terminal.WriteLine("Press (1) for your Local Store");
		Terminal.WriteLine("Press (2) for you Police Records");
		Terminal.WriteLine("Press (3) for the Local Bank");
		Terminal.WriteLine("");
		Terminal.WriteLine("Type menu to return to the main menu");
		Terminal.WriteLine("");
		Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput (string input)
	{
		if(input == "menu")
		{
			ShowMainMenu();
		}
		else if(input == "quit" || input == "close" || input == "exit")
		{
			Application.Quit();
		}
		else if(currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if(currentScreen == Screen.password)
		{
			CheckPassword(input);
		}
	}

	void RunMainMenu (string input)
	{
		bool isValidNumber = (input == "1" | input == "2" || input == "3");

		if(isValidNumber)
		{
			level = int.Parse(input);
			AskForPassword();
		}
		else
		{
			Terminal.WriteLine("Please Pick a valid option");
			Terminal.WriteLine(menuHint);
		}
	}

	void AskForPassword ()
	{
		currentScreen = Screen.password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
		Terminal.WriteLine(menuHint);
	}

	void SetRandomPassword ()
	{
		switch(level)
		{
			case 1:
				password = localStorePasswords[Random.Range(0, localStorePasswords.Length)];
				Terminal.WriteLine("You have chossen to hack the Local Store");
				break;
			case 2:
				password = policeRecordPasswords[Random.Range(0, policeRecordPasswords.Length)];
				Terminal.WriteLine("You have chossen to hack your Records");
				break;
			case 3:
				password = localBankPasswords[Random.Range(0, localBankPasswords.Length)];
				Terminal.WriteLine("You have chossen to hack the Local Bank");
				break;
			default:
				Debug.LogError("invalid number");
				break;
		}
	}

	void CheckPassword (string input)
	{
		if(input == password)
		{
			DisplayWinScreen();
		}
		else
		{
			AskForPassword();

		}
	}

	void DisplayWinScreen ()
	{
		currentScreen = Screen.win;
		Terminal.ClearScreen();
		ShowLevelReward();
		Terminal.WriteLine(menuHint);

	}

	void ShowLevelReward ()
	{
		switch(level)
		{
			case 1:
				Terminal.WriteLine("You Have a candle ....");
				Terminal.WriteLine(@"

        )
       (_)
       |`|
       | |  _()
     \_|_|_/	
		
");

				break;
			case 2:
				Terminal.WriteLine("you Have the handcuffs ....");
				Terminal.WriteLine(@"
        _    .----.       .----.
( )  //--\  \.---./  /--\\
 T  ((    ) @)   (@ (    ))
 |   \\__/  /'---'\  \__//
 |E   '----'       '----'	
	
");
				break;
			case 3:
				Terminal.WriteLine("You Have money ....");
				Terminal.WriteLine(@"

|#######====================#######|
|#(1)*UNITED STATES OF AMERICA*(1)#|
|#**          /===\   ********  **#|
|*# {G}      | ("") |            #*|
|#*  ******  | /v\ |    O N E    *#|
|#(1)         \===/            (1)#|
|##=========ONE DOLLAR===========##|	
		
");

				break;
			
		}
		Terminal.WriteLine("Well done");
	}

}
