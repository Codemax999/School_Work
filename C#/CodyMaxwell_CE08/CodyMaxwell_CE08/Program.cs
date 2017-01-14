using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE08
{
    class Program
    {
        static void Main(string[] args)
        {
            //create method that takes two parameters 1) array of strings and 2) boolean
            //method body sorts array of strings using an insertion sort alogorithm in either ascending or descending order based on boolean parameter 
            //strings have an inherited method called CompareTo that can be used for determining the sort order of two strings

            //welcome
            Console.WriteLine("Welcome to word sort...\r\nHere is the current word oder:\r\n");

            //define array of strings
            string[] words = new string[] {"hello", "today", "banjo", "programming"};

            //show current order
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }

            while (true)
            {
                //create reference for sort method call
                Program pro = new Program();

                //ask user for ascending or descending
                Console.WriteLine("\r\nPlease choose which way to sort these words...\r\n1) Ascending\r\n2) Descending\r\n3) Exit\r\n");
                Console.WriteLine("Enter the number of the sorting type you would like to do:");

                //capture user response
                string sortChoice = Console.ReadLine();

                //validate response
                switch (sortChoice)
                {
                    case "1":
                        pro.SortArray(words, true);
                        break;
                    case "2":
                        pro.SortArray(words, false);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("\r\nPlease only enter items from the list");
                        break;
                }
            }
        }

        private void SortArray(string[] _strings, bool _sortOrder)
        {
            //sort ints
            int sortLevelOne = 0;
            int sortLevelTwo = 0;

            //sort ascending
            if (_sortOrder == true)
            {
                sortLevelOne = 1;
                sortLevelTwo = -1;
            } 
            //sort descending
            else
            {
                sortLevelOne = -1;
                sortLevelTwo = 1;
            }

            //counter
            int counter = 0;

            //loop through array
            for (int i = 1; i < _strings.Length; i++)
            {
                //compare current index to next
                if (_strings[counter].CompareTo(_strings[i]) == sortLevelOne)
                {
                    //values of current index and next
                    string current = _strings[counter];
                    string next = _strings[i];

                    //swap places
                    _strings[counter] = next;
                    _strings[i] = current;

                    //lower index counter
                    int subCounter = counter;

                    //test against earlier array indexes if they exist
                    while (subCounter > 0)
                    {
                        if (_strings[subCounter].CompareTo(_strings[subCounter - 1]) == sortLevelTwo)
                        {
                            string newCurrent = _strings[subCounter];
                            string newPrevious = _strings[subCounter - 1];

                            //swap places
                            _strings[subCounter] = newPrevious;
                            _strings[subCounter - 1] = newCurrent;
                        }

                        //update subcounter
                        subCounter--;
                    }
                }

                //update counter
                counter++;
            }

            //display updated list
            Console.WriteLine("\r\nNew Word Order: \r\n");

            //print sorted array
            foreach (string word in _strings)
            {
                Console.WriteLine(word);
            }
        }
    }
}
