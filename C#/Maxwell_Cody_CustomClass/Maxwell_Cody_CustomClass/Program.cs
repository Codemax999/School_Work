using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_CustomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Cody Maxwell
                07/27/2016
                MDV2330-O
                Assignment: Custom Class
            */

            // Pass intial values to Shelter class
            Shelter initialShelterCount = new Shelter(20, 0, 10);

            // Display current count of dogs in shelter
            Console.WriteLine("There are currently {0} dogs in the shelter.", initialShelterCount.GetCurrent());

            // For loop to ask for user prompts
            for (int i = 0; i < 5; i++)
            {
                // Ask user if dogs increased or decreased
                Console.WriteLine("Please enter the word increase to have dogs added or enter decrease to remove dogs.");

                // Get user response 
                string typeResponse = Console.ReadLine();

                // While loop to handle user input validation
                while (typeResponse.ToLower().Trim() != "increase" && typeResponse.ToLower().Trim() != "decrease")
                {
                    // Alert user to enter valid input
                    Console.WriteLine("Only enter 'increase or 'decrease.'");
                    Console.WriteLine("Please enter the word increase if dogs have been added or enter decrease if dogs have been removed.");

                    // Get new response
                    typeResponse = Console.ReadLine();
                }

                // Ask the user how many dogs they would like to increase or decrease by
                Console.WriteLine("How many dogs would you like to {0} by?", typeResponse);

                // Get user response
                string numberResponse = Console.ReadLine();

                // Declare variable for output int
                int numResponse;

                // While loop to see that a valid number was given
                while (!int.TryParse(numberResponse, out numResponse))
                {
                    // Alert user to enter valid input
                    Console.WriteLine("Please only enter valid numbers.\r\nHow many dogs would you like to {0} by?", typeResponse);

                    // Get new response 
                    numberResponse = Console.ReadLine();                    
                }

                // Pass paramaters to function 
                int update = initialShelterCount.UpdateDogs(typeResponse, initialShelterCount.GetCurrent(), initialShelterCount.GetMax(), numResponse);

                // Update the current amount of dogs in the shelter
                initialShelterCount.SetCurrent(update);

                // Print out current number of dogs in shelter
                Console.WriteLine("There are currently {0} dogs in the shelter.", update.ToString());
            }
        }
    }
}
