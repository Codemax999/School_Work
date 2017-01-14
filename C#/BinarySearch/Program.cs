using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BinarySearch
{
    class Program
    {
        //DO NOT MODIFY MAIN()////////////////////////////////////
        //there are methods written below that you will implement to make this project function.
        static void Main(string[] args)
        {
            Character[] characters = Utility.ReadJsonData();

            while (true)
            {
                Console.WriteLine("Select what you would like to do.");
                Console.WriteLine("1. Display characters.");
                Console.WriteLine("2. Sort characters.");
                Console.WriteLine("3. Search through characters.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        foreach(Character c in characters)
                        {
                            Console.WriteLine(c);
                        }
                        break;
                    case "2":
                        SortCharacters(characters);
                        break;
                    case "3":
                        SearchCharacters(characters);
                        break;
                    default:
                        return;
                }
            }
        }
        ////////////////////////////////////////////////////////////////

        //Write your code in this area

        //Have the user select what to sort by (Name, Weapon Name and Total Defense as options)
        static void SortCharacters(Character[] characters)
        {
            Console.WriteLine("Which field would you like to sort by? (1 Name) (2 WeaponName) (3 TotalDefense)");
            Console.WriteLine("\r\nEnter the item number of the property you would like to sort by:");

            //user search type
            string userSearchType = Console.ReadLine();

            //updated characters
            Character[] sortedArray;

            //validate
            switch (userSearchType)
            {
                case "1":
                    Character[] sortedCharactersName = SortCharactersForSearch(characters, userSearchType);
                    sortedArray = sortedCharactersName;
                    break;
                case "2":
                    Character[] sortedCharactersWeaponName = SortCharactersForSearch(characters, userSearchType);
                    sortedArray = sortedCharactersWeaponName;
                    break;
                case "3":
                    Character[] sortedCharactersTotalDefense = SortCharactersForSearch(characters, userSearchType);
                    sortedArray = sortedCharactersTotalDefense;
                    break;
                default:
                    Console.WriteLine("\r\nItem not found, please try again.\r\n");
                    return;
            }
            //display updated list
            Console.WriteLine("\r\nNew Order: \r\n");

            //print sorted array
            foreach (Character c in sortedArray)
            {
                Console.WriteLine(c);
            }
        }

        //Have the user select what field to search for AND what value they want to search for in that field (Name, Weapon Name, and Total Defense as options)
        //Instead of returning the index, at the end of this method write the index to the console
        static void SearchCharacters(Character[] characters)
        {
            Console.WriteLine("Which field would you like to search? (1 Name) (2 WeaponName) (3 TotalDefense)");
            Console.WriteLine("\r\nEnter the item number of the property you would like to sort by:");

            //user search type
            string userSearchType = Console.ReadLine();

            //updated characters
            Character[] sortedArray;

            //search comparison
            int comparison = 0;

            //validate
            switch(userSearchType)
            {
                case "1":
                    Character[] sortedCharactersName = SortCharactersForSearch(characters, userSearchType);
                    sortedArray = sortedCharactersName;
                    break;
                case "2":
                    Character[] sortedCharactersWeaponName = SortCharactersForSearch(characters, userSearchType);
                    sortedArray = sortedCharactersWeaponName;
                    break;
                case "3":
                    Character[] sortedCharactersTotalDefense = SortCharactersForSearch(characters, userSearchType);
                    sortedArray = sortedCharactersTotalDefense;
                    break;
                default:
                    Console.WriteLine("\r\nItem not found, please try again.\r\n");
                    return;
            }

            //Get value to search for
            Console.WriteLine("\r\nPlease enter the value you would like to search for:");

            //search value
            string searchValue = Console.ReadLine();

            int min = 0;
            int length = sortedArray.Length;
            int max = length - 1;

            //binary sort
            while(min <= max)
            {
                int mid = (min + max) / 2;

                switch (userSearchType)
                {
                    case "1":
                        comparison = searchValue.CompareTo(sortedArray[mid].Name);
                        break;
                    case "2":
                        comparison = searchValue.CompareTo(sortedArray[mid].EquippedWeapon.Name);
                        break;
                    case "3":
                        comparison = Int32.Parse(searchValue).CompareTo(sortedArray[mid].GetTotalDefense());
                        break;
                }

                if (comparison > 0)
                {
                    //check above middle
                    min = mid + 1;
                }
                else
                {
                    //check below middle
                    max = mid - 1;
                }
                
                //character found
                if (comparison == 0)
                {
                    //name found
                    Console.WriteLine("\r\n - Character Found - \r\n");
                    Console.WriteLine(characters[mid]);
                    return;
                }
            }

            //character not found
            Console.WriteLine("Character not found, please try again.");
        }

        static Character[] SortCharactersForSearch(Character[] characters, string type)
        {
            //insertion sort
            int counter = 0;

            //loop through array of characters
            for (int i = 1; i < characters.Length; i++)
            {
                //parameters for comparison
                string currentParameter = "";
                string nextParameter = "";

                //comparison
                int comparison = 0;

                //update sort parameter based on user input
                switch (type)
                {
                    case "1":
                        currentParameter = characters[counter].Name;
                        nextParameter = characters[i].Name;
                        comparison = currentParameter.CompareTo(nextParameter);
                        break;
                    case "2":
                        currentParameter = characters[counter].EquippedWeapon.Name;
                        nextParameter = characters[i].EquippedWeapon.Name;
                        comparison = currentParameter.CompareTo(nextParameter);
                        break;
                    case "3":
                        int intParamter = characters[counter].GetTotalDefense();
                        int intNextParameter = characters[i].GetTotalDefense();
                        comparison = intParamter.CompareTo(intNextParameter);
                        break;
                    default:
                        Console.WriteLine("\r\nItem is not in list, please try again.\r\n");
                        return characters;
                }

                //compare current index Name to next
                if (comparison > 0 || comparison == 0)
                {
                    //values of current index and next
                    Character current = characters[counter];
                    Character next = characters[i];

                    //swap places
                    characters[counter] = next;
                    characters[i] = current;

                    //lower index counter
                    int preCounter = counter;

                    //test agains earlier array indexes if they exist
                    while (preCounter > 0)
                    {
                        //parameters for comparison
                        string subCurrentParameter = "";
                        string subPreviousParameter = "";

                        //sub comparison
                        int subcomparison = 0;

                        //update sort parameter based on user input
                        if (type == "1")
                        {
                            subCurrentParameter = characters[preCounter].Name;
                            subPreviousParameter = characters[preCounter - 1].Name;

                            subcomparison = subCurrentParameter.CompareTo(subPreviousParameter);
                        }
                        else if (type == "2")
                        {
                            subCurrentParameter = characters[preCounter].EquippedWeapon.Name;
                            subPreviousParameter = characters[preCounter - 1].EquippedWeapon.Name;

                            subcomparison = subCurrentParameter.CompareTo(subPreviousParameter);
                        }
                        else
                        {
                            int intSubParamter = characters[preCounter].GetTotalDefense();
                            int intPreviousParameter = characters[preCounter - 1].GetTotalDefense();

                            subcomparison = intSubParamter.CompareTo(intPreviousParameter);
                        }

                        if (subcomparison < 0 || subcomparison == 0)
                        {
                            Character preCurrent = characters[preCounter];
                            Character prePrevious = characters[preCounter - 1];

                            //swap places
                            characters[preCounter] = prePrevious;
                            characters[preCounter - 1] = preCurrent;
                        }

                        //update precounter
                        preCounter--;
                    }
                }

                //update counter
                counter++;
            }
            return characters;
        }
    }
}
