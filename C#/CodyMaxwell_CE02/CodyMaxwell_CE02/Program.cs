using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE02
{
    class Program
    {
        /*
         * Cody Maxwell
         * 11 - 26 - 2016
         * MDV2430-O
         * Code Exercise 02: Accessing Classes
         */

        //one static character object, default empty
        static Character mDefaultCharacter = new Character();

        static void Main(string[] args)
        {

            /*
             * create objects with object setters via user input
             * prompt explaination for all input
             *  display any updated data
             *  loop program until exit
             *  if character is currently null, let user know
             *  if character exists at least display the name
            */

            //greet user 
            Console.WriteLine("Hello and welcome to the character and weapon builder...");

            /*
             * user choice and case insensitive
             * 1- create a new character: Create Character or 1
             * 2- modify main static character: Modify Character or 2
             * 3- create a new weapon and set as static character's equipped weapon: Create and Equip Weapon or 3
             * 4- display information about the static character: Display Character Data or 4
             * 5- exit: Exit or 5
            */

            //set bool for looping project
            bool endProgram = false;

            //loop project untill 5 or Exit is entered
            while (endProgram == false)
            {
                //current user details: Name
                string currentUserName = (mDefaultCharacter.Name == null) ? "NOT SET" : mDefaultCharacter.Name;

                //display current user and menu
                Console.WriteLine("\r\n - MENU -");
                Console.WriteLine("\r\n -The current user is: {0}.", currentUserName);
                Console.WriteLine(" -Please select an item from the menu.\r\n -To select an item, enter the number or name of the item.\r\n");
                Console.WriteLine("1) Create Character\r\n2) Modify Character\r\n3) Create and Equip Weapon\r\n4) Display Character Data\r\n5) Exit");

                //capture user response
                string menuResponse = Console.ReadLine();

                //validate entry 
                if (menuResponse == "1" || menuResponse.ToLower().Trim() == "create character")
                {
                    /*
                     * 1 - create a character
                     * instantiates a Character Obj
                     * fills out its primitive type member variables
                     * sets the static character in program equal to new character
                     */

                    //display selection
                    Console.WriteLine("\r\n - CREATE A CHARACTER -");

                    //ask user for character name 
                    Console.WriteLine("\r\nPlease set your character's name:");

                    //capture user response
                    string responseCharacterName = Console.ReadLine();

                    //validate response
                    while (string.IsNullOrWhiteSpace(responseCharacterName))
                    {
                        //ask user for character name 
                        Console.WriteLine("\r\n - Do not leave this empty.\r\n - Please set your character name:");

                        //capture user response
                        responseCharacterName = Console.ReadLine();
                    }

                    //ask user for character base attack
                    Console.WriteLine("\r\nThank you, your character name is: {0}", responseCharacterName);
                    Console.WriteLine("Please set your character base attack amount to a whole number greater than 0:");

                    //capture user response
                    string responseCharacterBaseAttack = Console.ReadLine();
                    int newBaseAttack;

                    //validate response
                    while (!int.TryParse(responseCharacterBaseAttack, out newBaseAttack) || newBaseAttack <= 0)
                    {
                        //ask user for character base attack
                        Console.WriteLine("\r\n - Only enter a valid whole number greater than 0.\r\n - Please enter your character's base attack amount:");

                        //capture user response
                        responseCharacterBaseAttack = Console.ReadLine();
                    }

                    //ask user for character health
                    Console.WriteLine("\r\nThank you, your character base attack is: {0}", responseCharacterBaseAttack);
                    Console.WriteLine("Please set your character default health count to a whole number greater than 0:");

                    //capture user response
                    string responseCharacterHealth = Console.ReadLine();
                    int newHealth;

                    //validate response
                    while (!int.TryParse(responseCharacterHealth, out newHealth) || newHealth <= 0)
                    {
                        //ask user for character health 
                        Console.WriteLine("\r\n - Only enter a valid whole number greater than 0.\r\n - Please enter your character's default health count:");

                        //capture user response
                        responseCharacterHealth = Console.ReadLine();
                    }

                    //ask user for character role
                    Console.WriteLine("\r\nThank you, your character default health is: {0}", responseCharacterHealth);
                    Console.WriteLine("Please set a description of your character's role:");

                    //capture user response
                    string responseCharacterRole = Console.ReadLine();

                    //validate user response 
                    while (string.IsNullOrWhiteSpace(responseCharacterRole))
                    {
                        //ask user for character name 
                        Console.WriteLine("\r\n - Do not leave this empty.\r\n - Please give a description of your character's role:");

                        //capture user response
                        responseCharacterRole = Console.ReadLine();
                    }

                    //ask user for character level
                    Console.WriteLine("\r\nThank you, your character role is: {0}", responseCharacterRole);
                    Console.WriteLine("Please set your character default level to a whole number greater than 0:");

                    //capture user response
                    string responseCharacterLevel = Console.ReadLine();
                    int newLevel;

                    //validate response
                    while (!int.TryParse(responseCharacterLevel, out newLevel) || newLevel <= 0)
                    {
                        //ask user for character health 
                        Console.WriteLine("\r\n - Only enter a valid whole number greater than 0.\r\n - Please enter your character's default level:");

                        //capture user response
                        responseCharacterLevel = Console.ReadLine();
                    }

                    //create new character and assign to static user
                    Character newCharacter = new Character(responseCharacterName, newBaseAttack, newHealth, responseCharacterRole, newLevel);
                    mDefaultCharacter = newCharacter;

                    //display new user name
                    Console.WriteLine("\r\n - NEW USER CREATED -\r\nNew User Name: {0}", mDefaultCharacter.Name);
                    //displaymew user base attack
                    Console.WriteLine("New User Base Attack: {0}", mDefaultCharacter.BaseAttack);
                    //display new user health
                    Console.WriteLine("New User Health: {0}", mDefaultCharacter.Health);
                    //display new user role
                    Console.WriteLine("New User Role: {0}", mDefaultCharacter.Role);
                    //display new user level
                    Console.WriteLine("New User Level: {0}", mDefaultCharacter.Level);
                }
                else if (menuResponse == "2" || menuResponse.ToLower().Trim() == "modify character")
                {
                    /*
                     * 2 - modify static character
                     * change member variables of static character
                     * display current data and ask by number which piece to change or cancel
                     */

                    Console.WriteLine("\r\n - UPDATE USER -");

                    if (currentUserName == "NOT SET")
                    {
                        //user has not been set yet
                        Console.WriteLine("\r\n - The current user has not been set yet.\r\n - Select 'Create Character' or '1' to set the user.");
                    }
                    else
                    {
                        //ask user which detail they want to change
                        Console.WriteLine("\r\nSelect which detail you would like to change by entering the detail number...");

                        //display current user name
                        Console.WriteLine("\r\n1) Current User Name: {0}", mDefaultCharacter.Name);
                        //display current user base attack
                        Console.WriteLine("2) Current User Base Attack: {0}", mDefaultCharacter.BaseAttack);
                        //display current user health
                        Console.WriteLine("3) Current User Health: {0}", mDefaultCharacter.Health);
                        //display current user role
                        Console.WriteLine("4) Current User Role: {0}", mDefaultCharacter.Role);
                        //display current user level
                        Console.WriteLine("5) Current User Level: {0}", mDefaultCharacter.Level);

                        //int for menu with and without weapon
                        int menuNum = 0;

                        //determine if user has a weapon
                        if (mDefaultCharacter.EquippedWeapon != null)
                        {
                            menuNum += 8;
                            //display current user weapon name
                            Console.WriteLine("6) Current User Weapon Name: {0}", mDefaultCharacter.EquippedWeapon.WeaponName);
                            //display current user weapon attack
                            Console.WriteLine("7) Current User Weapon Attack: {0}", mDefaultCharacter.EquippedWeapon.Attack);
                            //cancel update
                            Console.WriteLine("{0}) Cancel Update and Return to Menu", menuNum);
                        }
                        else
                        {
                            menuNum += 6;
                            //cancel update
                            Console.WriteLine("{0}) Cancel Update and Return to Menu", menuNum);
                            //no weapons
                            Console.WriteLine("The current user has no weapons equipped.");
                        }

                        //capture user response
                        Console.WriteLine("\r\nPlease enter a number between 1 and {0}:", menuNum);
                        string responseEditNumber = Console.ReadLine();
                        int editNum;

                        //validate user response 
                        while (!int.TryParse(responseEditNumber, out editNum) || editNum < 1 || editNum > menuNum)
                        {
                            //ask user for valid response
                            Console.WriteLine("\r\n - Only enter a valid whole numbers.\r\n - Please enter a number between 1 and {0}:", menuNum);

                            //capture user response
                            responseEditNumber = Console.ReadLine();
                        }

                        //edit user detail based on number selection
                        if (editNum == 1)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE USER NAME -\r\nCurrent User Name: {0}", mDefaultCharacter.Name);
                            //ask user for new user name
                            Console.WriteLine("\r\nWhat would you like to change the user's name to?");

                            //capture user response
                            string newUserName = Console.ReadLine();

                            //validate response 
                            while (string.IsNullOrWhiteSpace(newUserName))
                            {
                                //do not leave blank and ask user for new user name
                                Console.WriteLine("\r\n - Please do not leave this blank. -\r\nWhat would you like to change the user's name to?");

                                //capture user response
                                newUserName = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.Name = newUserName;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new name is {0}", mDefaultCharacter.Name);

                        }
                        else if (editNum == 2)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE USER BASE ATTACK -\r\nCurrent User Base Attack: {0}", mDefaultCharacter.BaseAttack);
                            //ask user for new user base attack
                            Console.WriteLine("\r\nWhat would you like to change the user's base attack amount to?");
                            Console.WriteLine("Please enter valid whole number greater than 0.");

                            //capture user response
                            string newUserBaseAttack = Console.ReadLine();
                            int newAttackInt;

                            //validate response 
                            while (!int.TryParse(newUserBaseAttack, out newAttackInt) || newAttackInt <= 0)
                            {
                                //enter valid number and ask user for new user base attack
                                Console.WriteLine("\r\n - Please enter valid whole number greater than 0. -\r\nWhat would you like to set the user's base attack to?");

                                //capture user response
                                newUserBaseAttack = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.BaseAttack = newAttackInt;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new base attack amount is {0}", mDefaultCharacter.BaseAttack);
                        }
                        else if (editNum == 3)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE USER HEALTH -\r\nCurrent User Health: {0}", mDefaultCharacter.Health);
                            //ask user for new user health amount
                            Console.WriteLine("\r\nWhat would you like to change the user's default health amount to?");
                            Console.WriteLine("Please enter valid whole number greater than 0.");

                            //capture user response
                            string newUserHealth = Console.ReadLine();
                            int newHealthInt;

                            //validate response 
                            while (!int.TryParse(newUserHealth, out newHealthInt) || newHealthInt <= 0)
                            {
                                //enter valid number and ask user for new user health
                                Console.WriteLine("\r\n - Please enter valid whole number greater than 0. -\r\nWhat would you like to set the user's default health to?");

                                //capture user response
                                newUserHealth = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.Health = newHealthInt;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new health amount is {0}", mDefaultCharacter.Health);
                        }
                        else if (editNum == 4)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE USER ROLE -\r\nCurrent User Role: {0}", mDefaultCharacter.Role);
                            //ask user for new user role
                            Console.WriteLine("\r\nWhat would you like to change the user's role to?");

                            //capture user response
                            string newUserRole = Console.ReadLine();

                            //validate response 
                            while (string.IsNullOrWhiteSpace(newUserRole))
                            {
                                //do not leave blank and ask user for new user role
                                Console.WriteLine("\r\n - Please do not leave this blank. -\r\nWhat would you like to change the user's role to?");

                                //capture user response
                                newUserRole = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.Role = newUserRole;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new role is {0}", mDefaultCharacter.Role);
                        }
                        else if (editNum == 5)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE USER LEVEL -\r\nCurrent User Level: {0}", mDefaultCharacter.Level);
                            //ask user for new user level
                            Console.WriteLine("\r\nWhat would you like to change the user's level to?");
                            Console.WriteLine("Please enter valid whole number greater than 0.");

                            //capture user response
                            string newUserLevel = Console.ReadLine();
                            int newLevelInt;

                            //validate response 
                            while (!int.TryParse(newUserLevel, out newLevelInt) || newLevelInt <= 0)
                            {
                                //enter valid number and ask user for new user health
                                Console.WriteLine("\r\n - Please enter valid whole number greater than 0. -\r\nWhat would you like to set the user's level to?");

                                //capture user response
                                newUserLevel = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.Level = newLevelInt;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new level is {0}", mDefaultCharacter.Level);
                        }
                        else if (editNum == 6 && mDefaultCharacter.EquippedWeapon == null)
                        {
                            //exit to menu
                        }
                        else if (editNum == 6)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE WEAPON NAME -\r\nCurrent Weapon Name: {0}", mDefaultCharacter.EquippedWeapon.WeaponName);
                            //ask user for new user weapon name
                            Console.WriteLine("\r\nWhat would you like to change the user's weapon name to?");

                            //capture user response
                            string newUserWeaponName = Console.ReadLine();

                            //validate response 
                            while (string.IsNullOrWhiteSpace(newUserWeaponName))
                            {
                                //do not leave blank and ask user for new user weapon name
                                Console.WriteLine("\r\n - Please do not leave this blank. -\r\nWhat would you like to change the user's weapon name to?");

                                //capture user response
                                newUserWeaponName = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.EquippedWeapon.WeaponName = newUserWeaponName;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new weapon name is {0}", mDefaultCharacter.EquippedWeapon.WeaponName);
                        }
                        else if (editNum == 7)
                        {
                            //display current amount 
                            Console.WriteLine("\r\n - UPDATE WEAPON ATTACK -\r\nCurrent Weapon Attack Amount: {0}", mDefaultCharacter.EquippedWeapon.Attack);
                            //ask user for new user weapon attack amount
                            Console.WriteLine("\r\nWhat would you like to change the user's weapon attack amount to?");
                            Console.WriteLine("Please enter valid whole number greater than 0.");

                            //capture user response
                            string newUserWeaponAttack = Console.ReadLine();
                            int newWeaponAttackInt;

                            //validate response 
                            while (!int.TryParse(newUserWeaponAttack, out newWeaponAttackInt) || newWeaponAttackInt <= 0)
                            {
                                //enter valid number and ask user for new user weapon attack amount
                                Console.WriteLine("\r\n - Please enter valid whole number greater than 0. -\r\nWhat would you like to set the user's weapon attack amount to?");

                                //capture user response
                                newUserWeaponAttack = Console.ReadLine();
                            }

                            //update user detail
                            mDefaultCharacter.EquippedWeapon.Attack = newWeaponAttackInt;

                            //print out update
                            Console.WriteLine("\r\n - ITEM UPDATED -\r\n");
                            Console.WriteLine("The user's new weapon attack amount is {0}", mDefaultCharacter.EquippedWeapon.Attack);
                        }
                        else
                        {
                            //return to menu
                        }
                    }
                }
                else if (menuResponse == "3" || menuResponse.ToLower().Trim() == "create and equip weapon")
                {
                    /*
                     * 3 - Create and Equip Weapon
                     * prompt user for weapon details
                     * create weapon
                     * assign as equipped weapon to static character
                     */

                    Console.WriteLine("\r\n - CREATE A WEAPON -");

                    if (currentUserName == "NOT SET")
                    {
                        //user has not been set yet
                        Console.WriteLine("\r\n - The current user has not been set yet.\r\n - Please set a user before the user weapon.\r\n - Select 'Create Character' or '1' to set the user.");
                    }
                    else
                    {
                        //ask for user weapon name
                        Console.WriteLine("\r\nPlease set the name of your characters weapon:");

                        //capture user response
                        string responseCharacterWeaponName = Console.ReadLine();

                        //validate user response 
                        while (string.IsNullOrWhiteSpace(responseCharacterWeaponName))
                        {
                            //ask user for character name 
                            Console.WriteLine("\r\nDo not leave this empty.\r\nPlease set the weapon name:");

                            //capture user response
                            responseCharacterWeaponName = Console.ReadLine();
                        }

                        //ask user for character weapon attack
                        Console.WriteLine("\r\nThank you, your character's weapon is: {0}", responseCharacterWeaponName);
                        Console.WriteLine("\r\nPlease set your character weapon attack amount to a whole number greater than 0:");

                        //capture user response
                        string responseCharacterWeaponAttack = Console.ReadLine();
                        int newWeaponAttack;

                        //validate response
                        while (!int.TryParse(responseCharacterWeaponAttack, out newWeaponAttack) || newWeaponAttack <= 0)
                        {
                            //ask user for character weapon attack
                            Console.WriteLine("\r\n - Only enter a valid whole number greater than 0.\r\n - Please enter your character's weapon attack amount:");

                            //capture user response
                            responseCharacterWeaponAttack = Console.ReadLine();
                        }

                        //create new weapon
                        Weapon newWeapon = new Weapon(newWeaponAttack, responseCharacterWeaponName);
                        //assign weapon to user
                        mDefaultCharacter.EquippedWeapon = newWeapon;

                        //print out users new weapon
                        Console.WriteLine("\r\n - NEW USER WEAPON SET -\r\n");
                        Console.WriteLine("User: {0} now has weapon: {1} with attack amount: {2}.", mDefaultCharacter.Name, mDefaultCharacter.EquippedWeapon.WeaponName, mDefaultCharacter.EquippedWeapon.Attack);
                    }
                }
                else if (menuResponse == "4" || menuResponse.ToLower().Trim() == "display character data")
                {
                    /*
                     * 4 - Display Character Data
                     * display data from static character
                     * use getters
                     * display character weapon if equipped
                     */

                    Console.WriteLine("\r\n - CURRENT USER DATA -");

                    if (currentUserName == "NOT SET")
                    {
                        //user has not been set yet
                        Console.WriteLine("\r\n - The current user has not been set yet.\r\n - Select 'Create Character' or '1' to set the user.");
                    }
                    else
                    {
                        //display current user name
                        Console.WriteLine("\r\nCurrent User Name: {0}", mDefaultCharacter.Name);
                        //display current user base attack
                        Console.WriteLine("Current User Base Attack: {0}", mDefaultCharacter.BaseAttack);
                        //display current user health
                        Console.WriteLine("Current User Health: {0}", mDefaultCharacter.Health);
                        //display current user position
                        Console.WriteLine("Current User Role: {0}", mDefaultCharacter.Role);
                        //display current user in battle
                        Console.WriteLine("Current User Level: {0}", mDefaultCharacter.Level);
                        
                        //determine if user has a weapon
                        if (mDefaultCharacter.EquippedWeapon != null)
                        {
                            //display current user weapon name
                            Console.WriteLine("Current User Weapon Name: {0}", mDefaultCharacter.EquippedWeapon.WeaponName);
                            //display current user weapon attack
                            Console.WriteLine("Current User Weapon Attack: {0}", mDefaultCharacter.EquippedWeapon.Attack);
                        }
                        else
                        {
                            //no weapon set
                            Console.WriteLine("Current User has NO WEAPON SET");
                        }
                    }
                }
                else if (menuResponse == "5" || menuResponse.ToLower().Trim() == "exit")
                {
                    /*
                     * 5 - Exit
                     * if selected exit program
                     */
                    endProgram = true;
                }
                else
                {
                    //invalid entry 
                    Console.WriteLine("\r\n - INVALID ENTRY - \r\n");
                }
            }
        }
    }
}
