using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE03
{
    /*
     * Cody Maxwell
     * 11 - 29 - 2016
     * MDV2430-O
     * Code Exercise 03: Inheritance and Polymorphism
     */
    class Program
    {
        //create Character
        static Character newCharacter = new Character();

        static void Main(string[] args)
        {
            //give user access to functionality 
            //user menu selection
            //Character needs to be created 
            //available options:
            //1) giving the Character a status effect (setting the statusEffect member)
            //2) using a Potion on the Character (instantiates a Potion and calls that Potion's Use method)
            //3)using a StatusMedicine on the Character (instantiates a StatusMedicine and calls that StatusMedicine's Use method)

            //greet user
            Console.WriteLine("Hello and welcom to the Potion and Medicine creator...");

            //set bool for looping project
            bool endProgram = false;

            //loop project until user chooses exit
            while (endProgram == false)
            {
                //default Character
                newCharacter.Name = "Code";

                //display menu
                Console.WriteLine("\r\n - MENU -\r\n");
                Console.WriteLine(" -Please select an item from the menu.\r\n -To select an item, enter the number of the item.\r\n");
                Console.WriteLine("1) Set User Status Effect\r\n2) Use a Potion\r\n3) Use a Medicine\r\n4) Display Character Information\r\n5) Exit");

                //capture user input
                string menuResponse = Console.ReadLine();

                //validate response
                if (menuResponse == "1")
                {
                    //ask user for statusEffect
                    Console.WriteLine("\r\nPlease enter the Character's Status Effect.");

                    //capture user input
                    string statusEffectReponse = Console.ReadLine();

                    //validate response 
                    while (string.IsNullOrWhiteSpace(statusEffectReponse))
                    {
                        //error: do not leave blank
                        Console.WriteLine("Do not leave this blank.\r\nPlease enter the Character's Status Effect");
                        //capture new response
                        statusEffectReponse = Console.ReadLine();
                    }

                    //set new status effect
                    newCharacter.StatusEffect = statusEffectReponse;

                    //display change
                    Console.WriteLine("\r\n - CHARACTER UPDATED -\r\nCharacter Status Effect set to {0}", newCharacter.StatusEffect);
                }
                else if (menuResponse == "2")
                {
                    //potion effect amount
                    int potionEffect = 5;

                    //create potion and use on Character
                    Potion newPotion = new Potion();
                    newPotion.intEffect = potionEffect;
                    newPotion.Use(newCharacter);

                    //display effect of postion on user
                    Console.WriteLine("\r\n - CHARACTER UPDATED -\r\nCharacter Health set to {0}", newCharacter.Health);
                }
                else if (menuResponse == "3")
                {
                    //verify if Character Status Effect is set
                    if (newCharacter.StatusEffect != null)
                    {
                        //ask for user input
                        Console.WriteLine("\r\nEnter a potion name to use on the Character.");

                        //capture user input
                        string potionResponse = Console.ReadLine();

                        //validate response 
                        while (string.IsNullOrWhiteSpace(potionResponse))
                        {
                            //error: do not leave this blanl
                            Console.WriteLine("Do not leave this blank.\r\nPlease enter the potion you would like to use.");
                            //capture new response
                            potionResponse = Console.ReadLine();
                        }

                        //create medicine and use on Character
                        StatusMedicine newStatusMedicine = new StatusMedicine();
                        newStatusMedicine.strEffect = potionResponse;
                        newStatusMedicine.Use(newCharacter);

                        //check if status effect is set
                        string characterStatusEffect = (newCharacter.StatusEffect == null || newCharacter.StatusEffect == "") ? "EMPTY" : newCharacter.StatusEffect;

                        //display effect of medicine on user
                        Console.WriteLine("\r\n - CHARACTER UPDATED -\r\nBased on your potion the Character Status Effect is {0}.",characterStatusEffect);
                    }
                    else
                    {
                        //error: set status effect
                        Console.WriteLine("\r\n - Please enter a Character Status Effect by entering 1 on the main menu.");
                    }
                }
                else if (menuResponse == "4")
                {
                    //check if status effect is set
                    string characterStatusEffect = (newCharacter.StatusEffect == null || newCharacter.StatusEffect == "") ? "NOT SET" : newCharacter.StatusEffect;

                    //display Character details
                    Console.WriteLine("\r\n - CHARACTER DETAILS -");
                    Console.WriteLine(" -The character name is: {0}", newCharacter.Name);
                    Console.WriteLine(" -The character health is: {0}", newCharacter.Health);
                    Console.WriteLine(" -The character status effect: {0}", characterStatusEffect);
                }
                else if (menuResponse == "5")
                {
                    //exit program
                    endProgram = true;
                } 
                else
                {
                    //invalid entry
                    Console.WriteLine("\r\nOnly enter valid whole number 1 - 5.");
                }
            }
        }
    }
}
