using System;

namespace LectureProject
{
    class Program
    {
        //this is the main character
        static Character mainCharacter;

        static void Main(string[] args)
        {
            //loop program
            while (true)
            {
                //show the menu
                Program pro = new Program();
                pro.PrintMenu();

                //get user input
                String userSelection = Console.ReadLine();
                userSelection = userSelection.ToLower();

                //handle user input
                //switch statement
                switch (userSelection)
                {
                    //case to create character
                    case "create character":
                    case "1":
                        pro.CreateCharacter();
                        break;
                    //case to modify character
                    case "modify character":
                    case "2":
                        if (mainCharacter != null)
                        {
                            pro.ModifyCharacter();
                        }
                        else
                        {
                            Console.WriteLine("No character to modify.");
                        }
                        break;
                    //case to equip weapon
                    case "equip weapon":
                    case "3":
                        if (mainCharacter != null)
                        {
                            pro.CreateAndEquipWeapon();
                        }
                        else
                        {
                            Console.WriteLine("No character to give a weapon to.");
                        }
                        break;
                    //case to display status
                    case "display status":
                    case "4":
                        if (mainCharacter != null)
                        {
                            mainCharacter.DisplayStatus();
                        }
                        else
                        {
                            Console.WriteLine("No character to display.");
                        }
                        break;
                    //case to set mainCharacter's statusEffect
                    case "set character status":
                    case "5":
                        if (mainCharacter != null)
                        {
                            pro.SetCharacterStatusEffect();
                        }
                        else
                        {
                            Console.WriteLine("No character to set the status of.");
                        }
                        break;
                    //case to create and use a potion
                    case "use potion":
                    case "6":
                        if (mainCharacter != null)
                        {
                            pro.CreateAndUsePotion();
                        }
                        else
                        {
                            Console.WriteLine("No character to use a potion on.");
                        }
                        break;
                    //case to create and use a status medicine
                    case "use status medicine":
                    case "7":
                        if (mainCharacter != null)
                        {
                            pro.CreateAndUseStatusMedicine();
                        }
                        else
                        {
                            Console.WriteLine("No character to use a status medicine on.");
                        }
                        break;
                    //case to exit
                    case "exit":
                    case "8":
                        return;
                    //default
                    default:
                        Console.WriteLine("Command not recognized.");
                        continue;
                }
            }

        }

        private void PrintMenu()
        {
            Console.WriteLine();
            if (mainCharacter != null)
            {
               Console.WriteLine("Current Character: " + mainCharacter.Name);
            }
            else {
                Console.WriteLine("No current character.");
            }
            Console.WriteLine();
            Console.WriteLine("Select an option.");
            Console.WriteLine("1. Create Character");
            Console.WriteLine("2. Modify Character");
            Console.WriteLine("3. Equip Weapon");
            Console.WriteLine("4. Display Status");
            Console.WriteLine("5. Set Character Status");
            Console.WriteLine("6. Use Potion");
            Console.WriteLine("7. Use Status Medicine");
            Console.WriteLine("8. Exit");
        }

        //creates a new mainCharacter
        private void CreateCharacter()
        {
            Console.WriteLine("Character's name?");
            string characterName = Console.ReadLine();
            string characterGender = "";
            int characterHealth = 0;
            int characterBaseAttack = 0;
            double characterAccuracy = 0.0;
            string inputStorage = "";

            //get the character's gender, validate input against m and f
            while (true)
            {
                Console.WriteLine("Character's gender? M/F");
                characterGender = Console.ReadLine();
                characterGender = characterGender.ToLower();

                if (characterGender.Equals("m") || characterGender.Equals("f"))
                {
                    break;
                }
                Console.WriteLine("Invalid input.");
            }

            //get health and validate that it is an int
            Console.WriteLine("Character's starting health? This needs to be a whole number.");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    characterHealth = Convert.ToInt32(inputStorage);
                    break;
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number.");
                }
            }

            //get attack and validate that it is an int
            Console.WriteLine("Character's starting attack? This needs to be a whole number.");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    characterBaseAttack = Convert.ToInt32(inputStorage);
                    break;
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number.");
                }
            }

            //gte accuracy and validate that it is a double
            Console.WriteLine("Character's starting accuracy? This can be a whole number or a decimal value");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    characterAccuracy = Convert.ToDouble(inputStorage);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number or decimal value.");
                }
            }
            
            //create a new Character to be the mainCharacter
            mainCharacter = new Character(characterName, characterHealth, characterBaseAttack, characterGender, characterAccuracy);
        }

        //modifies the current mainCharacter's values
        private void ModifyCharacter()
        {
            Console.WriteLine("Character's name?");
            string characterName = Console.ReadLine();
            string characterGender = "";
            int characterHealth = 0;
            int characterBaseAttack = 0;
            double characterAccuracy = 0.0;
            string inputStorage = "";

            //get the gender and validate the input against m and f
            while (true)
            {
                Console.WriteLine("Character's gender? M/F");
                characterGender = Console.ReadLine();
                characterGender = characterGender.ToLower();

                if (characterGender.Equals("m") || characterGender.Equals("f"))
                {
                    break;
                }
                Console.WriteLine("Invalid input.");
            }

            //get health and validate that it is an int
            Console.WriteLine("Character's starting health? This needs to be a whole number.");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    characterHealth = Convert.ToInt32(inputStorage);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number.");
                }
            }

            //get attack and validate it is an int
            Console.WriteLine("Character's starting attack? This needs to be a whole number.");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    characterBaseAttack = Convert.ToInt32(inputStorage);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number.");
                }
            }

            //get accuracy and validate it is a double
            Console.WriteLine("Character's starting accuracy? This can be a whole number or a decimal value");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    characterAccuracy = Convert.ToDouble(inputStorage);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number or decimal value.");
                }
            }

            //set the current mainCharacter's values to the new values
            mainCharacter = new Character(characterName, characterHealth, characterBaseAttack, characterGender, characterAccuracy);
        }

        //create a new weapon and equip it
        private void CreateAndEquipWeapon()
        {
            int weaponAttack = 0;
            string weaponName = "";
            string inputStorage = "";
            Weapon newWeapon = null;

            //get the weapon name
            Console.WriteLine("Weapon's name?");
            weaponName = Console.ReadLine();

            //get the attack value and validate that it is an int
            Console.WriteLine("Weapon's attack value? This needs to be a whole number.");
            while (true)
            {
                inputStorage = Console.ReadLine();
                try
                {
                    weaponAttack = Convert.ToInt32(inputStorage);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Needs to be a whole number.");
                }
            }
            
            //is it a melee or ranged weapon?
            while (true)
            {
                Console.WriteLine("Is this a ranged or melee weapon?");
                inputStorage = Console.ReadLine();
                inputStorage = inputStorage.ToLower();

                if (inputStorage.Equals("ranged"))
                {
                    //get the range of the weapon and validate it is a double
                    Console.WriteLine("Ranged weapon's range value? This can be a whole number or decimal.");
                    double weaponRange = 0;
                    while (true)
                    {
                        inputStorage = Console.ReadLine();
                        try
                        {
                            weaponRange = Convert.ToDouble(inputStorage);
                            break;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid input. Needs to be a whole number or decimal.");
                        }
                    }
                    //set our local weapon variable
                    newWeapon = new RangedWeapon(weaponAttack, weaponName, weaponRange);
                    break;
                }
                else if (inputStorage.Equals("melee"))
                {
                    //get the reach of the weapon and validate it is a double
                    double weaponReach = 0;
                    Console.WriteLine("Melee weapon's reach value? This can be a whole number or decimal.");
                    while (true)
                    {
                        inputStorage = Console.ReadLine();
                        try
                        {
                            weaponReach = Convert.ToDouble(inputStorage);
                            break;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid input. Needs to be a whole number or decimal.");
                        }
                    }
                    //set our local weapon variable
                    newWeapon = new MeleeWeapon(weaponAttack, weaponName, weaponReach);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            //equip the new weapon to the main character
            newWeapon.Equip(mainCharacter);
        }

        //set the character's status effect
        private void SetCharacterStatusEffect()
        {
            Console.WriteLine("What status should the character be afflicted with?");
            mainCharacter.StatusEffect = Console.ReadLine();
        }

        //create a new potion and use it on the mian character
        private void CreateAndUsePotion()
        {
            Potion smallPotion = new Potion(30, "", "Small Potion");
            smallPotion.Use(mainCharacter);
        }

        //create a new status medicine and use it on the main character
        private void CreateAndUseStatusMedicine()
        {
            Console.WriteLine("What status should the medicine be able to cure?");
            string inputStorage = Console.ReadLine();

            StatusMedicine statusMedicine = new StatusMedicine(0, inputStorage, "Cures " + inputStorage);
            statusMedicine.Use(mainCharacter);
        }
    }
}
