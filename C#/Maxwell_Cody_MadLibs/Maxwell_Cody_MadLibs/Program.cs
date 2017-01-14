using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_MadLibs
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
               Cody Maxwell
               07/03/2016
               MDV2330
               Assignment: MadLibs Style Story Creator
            */

            // 4 word strings
            string pet = "";
            string place = "";
            string celebrity = "";
            string expression = "";

            // 3 number strings
            string days = "";
            string fans = "";
            string cost = "";

            // Enter an animal type and save it to pet variable
            Console.WriteLine("Enter a type of animal: ");
            pet = Console.ReadLine();

            // Enter a place and save it to place variable
            Console.WriteLine("Enter a place: ");
            place = Console.ReadLine();

            // Enter a celebrity and save it to celebrity variable
            Console.WriteLine("Enter a celebrity: ");
            celebrity = Console.ReadLine();

            // Enter a facial expression and save it to the expression variable
            Console.WriteLine("Enter a facial expression: ");
            expression = Console.ReadLine();

            // Enter a number between 1 and 100 and save it to the days variable
            Console.WriteLine("Enter a number between 1 and 100: ");
            days = Console.ReadLine();

            // Enter a number between 1 and 1000 and save it to the fans variable
            Console.WriteLine("Enter a number between 1 and 1000");
            fans = Console.ReadLine();

            // Enter any number and save it to the cost variable
            Console.WriteLine("Enter any number: ");
            cost = Console.ReadLine();

            // Convert number strings to doubles
            double newDays = double.Parse(days);
            double newFans = double.Parse(fans);
            double newCost = double.Parse(cost);

            // Add strings to string array 
            string[] words = new string[] { pet, place, celebrity, expression };

            // Add doubles to double array
            double[] numbers = new double[] { newDays, newFans, newCost };

            // Print out full sentence to the console
            Console.WriteLine("For the past " + numbers[0] + " days I have taken my pet " + words[0] + " to the " + words[1] + ".");
            Console.WriteLine("Each time I go, at least " + numbers[1] + " people mistake him for " + words[2] + " and ask for an autograph.");
            Console.WriteLine("I just " + words[3] + " and say, " + numbers[2] + " dollars.");
        
        }
    }
}
