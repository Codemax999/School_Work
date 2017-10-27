using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDI_Find_Errors_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            //  NAME:  Cody Maxwell
            //  DATE:  07/14/2016
            //  Scalable Data Infrastructures
            //  Day 4 Lab
            //  Find and fix the errors
            //  Assignment: Find The Error Conditionals

            // Assign variable values
            String myName = "John Doe";
            String myJob = "Cat Wrangler";

            int numberOfCats = 40;
            Boolean employed = true;

            // Greeting
            Console.WriteLine("Hello!  My name is " + myName + ".");
            Console.WriteLine("I'm a " + myJob + ".");
            Console.WriteLine("My current assignment has me wrangling " + numberOfCats + " cats.");
            Console.WriteLine("So, let's get to work!");

            // Loop through number of cats wrangled
            while (numberOfCats > 0) {

                // If still employed, continue to wrangle up cats
                if (employed == true) {

                    Console.WriteLine("I've wrangled another cat.  Only " + numberOfCats + " left!");

                // Else cease cat wrangling
                } else {

                    Console.WriteLine("I've been fired!  Someone else will have to wrangle the rest!");
                    break;

                };

                // Remove a cat from the list of cats to be wrangled
                numberOfCats--;

                // If 5 cats remain, fire the cat wrangler : (
                if (numberOfCats == 5) {

                    employed = false;

                }

            }

        }
    }
}





            