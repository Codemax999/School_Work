using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    class Program
    {
        //Main Character
        static Character mainCharacter = new Character();

        static void Main(string[] args)
        {
            //character needs to be created before things can be added
            //creating items places them in inventory List of the Character
            //equip display inventory List and allows user to select and Equip items to Dictionary
            //equipped items move from inventory List to Dictionary of equipped items
            //Dictionary equipped items are replaced and added back to inventory List

            //member class variables
            Program pro = new Program();

            //create a character
            pro.CreateCharacter();

            while (true)
            {
                //print menu
                pro.PrintMenu();

                //user selection
                String userMenuSelection = Console.ReadLine();

                //validate entry
                switch (userMenuSelection)
                {
                    //create weapon
                    case "1":
                        pro.CreateWeapon();
                        break;
                        //create armor
                    case "2":
                        pro.CreateArmor();
                        break;
                    //equip item
                    case "3":
                        pro.EquipItem();
                        break;
                    //view equippables
                    case "4":
                        return;
                    //not found
                    default:
                        Console.WriteLine("\r\ncommand not found, please try again...");
                        break;
                }
            }
        }

        private void CreateCharacter()
        {
            //member class variables
            Program pro = new Program();

            //greet user
            Console.WriteLine("WELCOME TO THE CHARACTER CREATOR");
            pro.PrintLine();

            //create character name
            String enterCharName = "Please enter your character's name:";
            Console.WriteLine(enterCharName);

            //capture response
            String mainName = Console.ReadLine();

            //validate response
            while (string.IsNullOrWhiteSpace(mainName))
            {
                //ERROR: no blank
                Console.WriteLine("\r\nDo not leave this blank.\r\n{0}", enterCharName);
                mainName = Console.ReadLine();
            }

            //create character base attack
            String enterCharBaseAttack = "Please enter your character's base attack:";
            Console.WriteLine(enterCharBaseAttack);

            //capture response 
            String mainBaseAttack = Console.ReadLine();
            int intMainBaseAttack;

            //validate response for empty
            while (string.IsNullOrWhiteSpace(mainBaseAttack) || !int.TryParse(mainBaseAttack, out intMainBaseAttack))
            {
                //ERROR: no blank
                Console.WriteLine("\r\nOnly enter valid whole numbers.\r\n{0}", enterCharBaseAttack);
                mainBaseAttack = Console.ReadLine();
            }

            //create character
            mainCharacter = new Character(mainName, intMainBaseAttack);
        }

        private void PrintLine()
        {
            Console.WriteLine("----------------------------------\r\n");
        }

        private void PrintMenu()
        {
            //member class variables
            Program pro = new Program();

            //user menu for character
            //1. Create Weapon 2. Create Armor 3. Equip 4. View Equippables 5. Exit 
            Console.WriteLine("\r\nCHARACTER MENU");
            
            //add line
            pro.PrintLine();

            //display user
            pro.DisplayStatus();

            //menu contents
            Console.WriteLine("\r\n1. Create Weapon\r\n2. Create Armor\r\n3. Equip Item\r\n4. Exit");
            Console.WriteLine("\r\nPlease make a selection by entering a number 1 - 4");

        }

        private void DisplayStatus()
        {
            //display current user
            Console.WriteLine("Current Character Name: {0}", mainCharacter.Name);
            Console.WriteLine("Current Character Base Attack: {0}", mainCharacter.BaseAttack);

            //if weapon set display
            if (mainCharacter.CurrentWeapon != null)
            {
                Console.WriteLine("Current Character Weapon Attack: {0}", mainCharacter.CurrentWeapon.Attack);
            }

            //current helmet if equipped
            Armor currentHelmet;
            
            //if armor set display
            if (mainCharacter.Armors.TryGetValue("helmet", out currentHelmet))
            {
                Console.WriteLine("Current Character Helmet Defense: {0}", currentHelmet.Defense);
            }

            //current chestpiece if equipped
            Armor currentChestpiece;

            //if armor set display
            if (mainCharacter.Armors.TryGetValue("chestpiece", out currentChestpiece))
            {
                Console.WriteLine("Current Character Chestpiece Defense: {0}", currentChestpiece.Defense);
            }
        }

        private void CreateWeapon()
        {
            //member class variables
            Program pro = new Program();

            //display selection
            Console.WriteLine("\r\nCREATE A WEAPON");
            pro.PrintLine();

            //enter weapon attack
            Console.WriteLine("\r\nPlease enter the weapon's attack:");

            //capture response 
            String weaponAttack = Console.ReadLine();
            int weaponAttackInt;

            //validate 
            while (string.IsNullOrWhiteSpace(weaponAttack) || !int.TryParse(weaponAttack, out weaponAttackInt))
            {
                //ERROR: empty
                Console.WriteLine("\r\nOnly enter valid whole numbers.\r\nPlease enter the weapon's attack:");
                //capture new response
                weaponAttack = Console.ReadLine();
            }

            //create weapon
            IEquippable newWeapon = new Weapon(weaponAttackInt);

            //add to inventory
            mainCharacter.Equippables.Add(newWeapon);

            //print out update
            Console.WriteLine("\r\n-----WEAPON ADDED TO INVENTORY-----");
        }

        private void CreateArmor()
        {
            //member class variables
            Program pro = new Program();

            //display selection
            Console.WriteLine("\r\nCREATE ARMOR");
            pro.PrintLine();

            //ask for helmet or chestpiece
            Console.WriteLine("\r\n1. Helmet\r\n2. Chestpiece");
            Console.WriteLine("\r\nPlease enter the number of the type of armor you would like to create:");

            //validate
            String armorType = Console.ReadLine();
            armorType.Trim();

            while (armorType != "1" && armorType != "2")
            {
                //ERROR: not valid
                Console.WriteLine("\r\nOnly enter a valid number.\r\nPlease enter the number type of the armor you would like to create:");
                armorType = Console.ReadLine();
            }

            //enter armor defense
            Console.WriteLine("\r\nPlease enter the armor's defense:");

            //capture response 
            String armorDefense = Console.ReadLine();
            int armorDefenseInt;

            //validate 
            while (string.IsNullOrWhiteSpace(armorDefense) || !int.TryParse(armorDefense, out armorDefenseInt))
            {
                //ERROR: empty
                Console.WriteLine("\r\nOnly enter valid whole numbers.\r\nPlease enter the weapon's attack:");
                //capture new response
                armorDefense = Console.ReadLine();
            }

            if (armorType == "1")
            {
                //armor is helmet
                IEquippable newHelmet = new Helmet(armorDefenseInt);
                //add to list
                mainCharacter.Equippables.Add(newHelmet);
            }
            else
            {
                //armor is chestpiece
                IEquippable newChestpiece = new Chestpiece(armorDefenseInt);
                //add to list
                mainCharacter.Equippables.Add(newChestpiece);
            }

            //print out update
            Console.WriteLine("\r\n-----ARMOR ADDED TO INVENTORY-----");
        }

        private void EquipItem()
        {
            //verify that there are equippables
            if (!mainCharacter.Equippables.Any())
            {
                //no equippables 
                Console.WriteLine("\r\n *** There are no items in the inventory.\r\n *** Please create a weapon or armor.");
                return;
            }
            //member class variables
            Program pro = new Program();

            //display selection
            Console.WriteLine("\r\nEQUIP AN ITEM");
            pro.PrintLine();

            Console.WriteLine("\r\nAVAILABLE INVENTORY");
            pro.PrintLine();

            //index counter
            int counter = 0;

            //print items
            foreach (IEquippable item in mainCharacter.Equippables)
            {
                if (item is Weapon)
                {
                    Console.WriteLine(counter + ". [WEAPON] attack: " + item.Attack);
                }

                if (item is Helmet)
                {
                    Console.WriteLine(counter + ". [ARMOR - HELMET] defense: "+ item.Defense);
                }

                if (item is Chestpiece)
                {
                    Console.WriteLine(counter + ". [ARMOR - CHESTPIECE] defense: " + item.Defense);
                }
                 
                //update counter
                counter++;
            }

            //enter item number to equip
            Console.WriteLine("\r\nEnter the number for the item you would like to equip:");

            //capture user input
            String userSelection = Console.ReadLine();
            int userSelectionInt;

            //validate number
            while(!int.TryParse(userSelection, out userSelectionInt) || userSelectionInt > counter - 1 || userSelectionInt < 0)
            {
                //error not on list
                Console.WriteLine("\r\nOnly enter numbers from the list.\r\nEnter the number for the item you would like to equip:");
                userSelection = Console.ReadLine();
            }

            //remove new item from inventory 
            IEquippable choosenItem = mainCharacter.Equippables[userSelectionInt];
            mainCharacter.Equippables.Remove(choosenItem);

            //check type 
            if (choosenItem is Weapon)
            {
                //remove current equipped weapon
                if (mainCharacter.CurrentWeapon != null)
                {
                    //move it back to inventory
                    mainCharacter.Equippables.Add(mainCharacter.CurrentWeapon);
                }
                //add choosen item to equipped weapon
                choosenItem.Equip(mainCharacter); 
            }
            else if (choosenItem is Helmet)
            {
                //remove current helmet from dictionary
                if (mainCharacter.Armors != null && mainCharacter.Armors.ContainsKey("helmet"))
                {
                    //assign to variable
                    Armor removedItem;
                    mainCharacter.Armors.TryGetValue("helmet", out removedItem);

                    //remove and add to inventory
                    mainCharacter.Armors.Remove("helmet");

                    //add it back to inventory as helmet
                    Helmet newHelmet = (Helmet)removedItem;
                    mainCharacter.Equippables.Add(newHelmet);
                }
                //add choose item to dictionary
                Armor newArmor = (Armor)choosenItem;
                newArmor.Equip(mainCharacter);
            }
            else if (choosenItem is Chestpiece)
            {
                //remove current chestpiece from dictionary
                if (mainCharacter.Armors != null && mainCharacter.Armors.ContainsKey("chestpiece"))
                {
                    //assign to variable
                    Armor removedItem;
                    mainCharacter.Armors.TryGetValue("chestpiece", out removedItem);

                    //remove and add to inventory
                    mainCharacter.Armors.Remove("chestpiece");

                    //add it back to inventory as chestpiece
                    Chestpiece newChestpiece = (Chestpiece)removedItem;
                    mainCharacter.Equippables.Add(newChestpiece);
                }
                //add choose item to dictionary
                Armor newArmor = (Armor)choosenItem;
                newArmor.Equip(mainCharacter);
            }

            //display change to user
            Console.WriteLine("\r\n-----USER UPDATED-----");
        }
    }
}
