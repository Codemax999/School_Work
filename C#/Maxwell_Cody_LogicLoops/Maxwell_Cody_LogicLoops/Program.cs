using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_LogicLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Cody Maxwell
                07/17/2016
                Scalable Data Infrastructures
                Assignment: Logic & Loops
            */

            // Question 1: Tire Pressure I
            Console.WriteLine("QUESTION 1");

            // Array for full car
            double[] fullCar = new double[] { 0,0,0,0 };

            // Boolean values to determine validation
            Boolean tireCheckOne = false;
            Boolean tireCheckTwo = false;
            Boolean tireCheckThree = false;
            Boolean tireCheckFinal = false;

            // Tire pressure one
            while (tireCheckOne == false)
            {
                // Ask for pressure
                Console.WriteLine("Please enter the tire pressure from the front left tire.");

                // Get and Validate user response
                string tireResponseOne = Console.ReadLine();

                // Check to see if response is number, if number update array index
                if (double.TryParse(tireResponseOne, out fullCar[0]))
                {
                    // Change truthiness of tireCheck
                    tireCheckOne = true;

                    // Move on to second tire
                    while (tireCheckTwo == false)
                    {
                        // Ask user for pressure of second tire
                        Console.WriteLine("Please enter the tire pressure from the front right tire.");

                        // Get and validate user response
                        string tireResponseTwo = Console.ReadLine();

                        // Check to see if response is a number, if number update array index
                        if (double.TryParse(tireResponseTwo, out fullCar[1]))
                        {
                            // Change truthiness of tireCheck
                            tireCheckTwo = true;

                            // Move on to third tire
                            while (tireCheckThree == false)
                            {
                                // Ask user for pressure of third tire
                                Console.WriteLine("Please enter the tire pressure from the back left tire.");

                                // Get and validate user response
                                string tireResponseThree = Console.ReadLine();

                                // Check to see if response is a number, if number update array index
                                if (double.TryParse(tireResponseThree, out fullCar[2]))
                                {
                                    // Change truthiness of tireCheck
                                    tireCheckThree = true;

                                    // Move on to fourth tire
                                    while (tireCheckFinal == false)
                                    {
                                        // Aask user for pressure of final tire
                                        Console.WriteLine("Please enter the tire pressure from the back right tire.");

                                        // Get an validate user response
                                        string tireResponseFinal = Console.ReadLine();

                                        // Check to see if response is a number, if number update array index
                                        if (double.TryParse(tireResponseFinal, out fullCar[3]))
                                        {
                                            // Compare front tires
                                            if (fullCar[0] != fullCar[1])
                                            {
                                                // Front tires not equal
                                                Console.WriteLine("Get your tires checked out!");
                                            } 
                                            else
                                            {
                                                // Front tires match, check back tires
                                                if (fullCar[2] != fullCar[3])
                                                {
                                                    // Back tires not equal
                                                    Console.WriteLine("Get you tires checked out!");
                                                } 
                                                else
                                                {
                                                    // Front tires match and back tires match
                                                    Console.WriteLine("The tires pass spec!"); 
                                                }
                                            }

                                            // Update truthiness of tireCheck to move on
                                            tireCheckFinal = true;
                                        }
                                        else if (string.IsNullOrWhiteSpace(tireResponseFinal))
                                        {
                                            // Nothing Entered
                                            Console.WriteLine("Do not leave this blank.");
                                        }
                                        else
                                        {
                                            // Not a valid number
                                            Console.WriteLine("Only enter a valid number");
                                        }
                                    }

                                }
                                else if (string.IsNullOrWhiteSpace(tireResponseThree))
                                {
                                    // Nothing Entered
                                    Console.WriteLine("Do not leave this blank.");
                                }
                                else
                                {
                                    // Not a valid number
                                    Console.WriteLine("Only enter a valid number.");
                                }
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(tireResponseTwo))
                        {
                            // Nothing Entered
                            Console.WriteLine("Do not leave this blank.");
                        } 
                        else
                        {
                            // Not a valid number
                            Console.WriteLine("Only enter a valid number.");
                        }
                    }
                }
                else if (string.IsNullOrWhiteSpace(tireResponseOne))
                {
                    // Nothing Entered
                    Console.WriteLine("Do not leave this blank.");
                }
                else
                {
                    // Not a valid number
                    Console.WriteLine("Only enter a valid number.");
                }
                
            }

            /* 
                -TEST VALUES-
                Question 1: 32
                Question 2: 32
                Question 3: 28
                Question 4: 28
                Result: Passes Spec
            */




            // Question 2: Movie Ticket Price
            Console.WriteLine("QUESTION 2");

            // Declare variables for movie time and person ages
            int movieTime = 0;
            string movieTimeOfDay = "";
            int personAge = 0;

            // Declare movie time and age validator
            Boolean movieChecker = false;
            Boolean timeOfDayChecker = false;
            Boolean ageChecker = false;

            // While loop until movie time is validated
            while (movieChecker == false)
            {
                // Ask user what time movie is at
                Console.WriteLine("What time would you like to see the movie?");

                // Get user response for movie time
                string timeResponse = Console.ReadLine();

                if (int.TryParse(timeResponse, out movieTime))
                {
                    // Number validated, check if number is greater than 12 or less than 1
                    if (movieTime > 12 || movieTime < 1)
                    {
                        // Tell user to only enter numbers between 1 and 12
                        Console.WriteLine("Please ony enter numbers between 1 and 12");
                    } 
                    else
                    {
                        // Update truthiness of movieChecker
                        movieChecker = true;

                        // Set while loop to validate time of day
                        while (timeOfDayChecker == false)
                        {
                            // Number is valid, ask for A or AM or P for PM
                            Console.WriteLine("Enter A for AM or P for PM.");

                            // Get user response for time of day
                            string timeOfDayResponse = Console.ReadLine();

                            // Validate response
                            if (timeOfDayResponse == "A" || timeOfDayResponse == "P")
                            {
                                // Update movie time of day string
                                movieTimeOfDay = timeOfDayResponse;

                                // Update truthiness of movieChecker to move on
                                timeOfDayChecker = true;

                                // While loop until age is validated
                                while (ageChecker == false)
                                {
                                    // Ask user for age
                                    Console.WriteLine("Enter your age.");

                                    // User age response 
                                    string userAgeResponse = Console.ReadLine();

                                    // Validate age value
                                    if (int.TryParse(userAgeResponse, out personAge))
                                    {
                                        // Check for fake ages
                                        if (personAge > 122 || personAge < 0)
                                        {
                                            // Fake age
                                            Console.WriteLine("Please enter a real age.");
                                        }
                                        else
                                        {
                                            // Real age, Calculate Ticket Price, check for discount
                                            if (personAge < 10 || personAge >= 55 || movieTime <= 5 && movieTime >= 3 && movieTimeOfDay == "P")
                                            {
                                                // Discount received 
                                                Console.WriteLine("The ticket price is $7.");
                                            }
                                            else
                                            {
                                                // Full Price
                                                Console.WriteLine("The ticket price is $10.");
                                            }
                                        }

                                        // Update ageChecker to move on
                                        ageChecker = true;
                                    }
                                    else if (string.IsNullOrWhiteSpace(userAgeResponse))
                                    {
                                        // Nothing Entered
                                        Console.WriteLine("Please do not leave this blank.");
                                    }
                                    else
                                    {
                                        // Not a valid number
                                        Console.WriteLine("Please only enter valid numbers.");
                                    }
                                }
                            }
                            else if (string.IsNullOrWhiteSpace(timeOfDayResponse))
                            {
                                // Nothing Entered
                                Console.WriteLine("Please do not leave this blank.");
                            }
                            else
                            {
                                // Not valid entry
                                Console.WriteLine("Please only enter capital A or capital P.");
                            }
                        }
                    }

                }
                else if (string.IsNullOrWhiteSpace(timeResponse))
                {
                    // Nothing Entered
                    Console.WriteLine("Please do not leave this blank.");
                }
                else
                {
                    // Not a valid number
                    Console.WriteLine("Please only enter a valid number.");
                }

            }

            /*
                -TEST VALUES-
                Movie Time: 11
                Time of Day: A
                Age: 9
                Result: $7 ticket
            */




            // Question 3: Add Up The Odds
            Console.WriteLine("Question 3");

            // Declare int for total
            int oddTotal = 0;

            // Declare array to add numbers to and array for odd numbers
            // For this it would be better to use a List as the size of the array is not known
            int[] numberList = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 };
            int[] oddList = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // Booleans to handle while loop validations
            Boolean moveOn = false;
            Boolean isFirst = true;

            // While loop to enter numbers to array
            while (moveOn == false)
            {
                if (isFirst == true)
                {
                    // Ask user to enter a number
                    Console.WriteLine("Please enter a number.");

                    // Get response
                    string firstResponse = Console.ReadLine();

                    // Check to see if valid number
                    if (int.TryParse(firstResponse, out numberList[0]))
                    {
                        // Update isFirst Boolean
                        isFirst = false;
                    }
                    else if (string.IsNullOrWhiteSpace(firstResponse))
                    {
                        // Nothing entered
                        Console.WriteLine("Do not leave this blank");
                    }
                    else
                    {
                        // Not a valid number
                        Console.WriteLine("Not a valid number.");
                    }
                }
                else
                {
                    // For loop to enter 12 array numbers
                    for (int i = 1; i <= 11; i++)
                    {
                        // Ask user for number and let them know they can move on
                        Console.WriteLine("Please enter another number or type 'move on' to continue.");

                        // Get user response
                        string nextResponse = Console.ReadLine();

                        // Check to see if response is valid number, if it is, add it to the array
                        if (i == 11)
                        {
                            // Verify input is number
                            if (int.TryParse(nextResponse, out numberList[i]))
                            {
                                // Move on as the array is full
                                moveOn = true;

                                // End loop
                                break;
                            }
                            else if (nextResponse == "move on") { }
                            {
                                // Update moveOn truthiness
                                moveOn = true;

                                // End loop
                                break;
                            }

                        }
                        else if (int.TryParse(nextResponse, out numberList[i]))
                        {
                            // Leave Blank
                        }
                        else if (nextResponse == "move on")
                        {
                            // Update moveOn truthiness
                            moveOn = true;

                            // End loop
                            break;
                        }
                        else
                        {
                            // Not a valid response
                            Console.WriteLine("Not a valid number.");
                        }
                    }
                }

            }

            // Use for loop to filter for odd numbers
            for (int i = 0; i < numberList.Length; i++)
            {
                // Filter for odd numbers
                if (numberList[i]%2 == 0)
                {
                    // i is even, skip
                    continue;
                }

                // i is odd, add it to odd array
                oddList[i] = numberList[i];
            }

            // Use for loop to add up odd numbers
            for (int i = 0; i < oddList.Length; i++)
            {
                // Add odd number to oddTotal
                oddTotal = oddTotal + oddList[i];
            }

            // Print out total 
            Console.WriteLine("The odd numbers add up to {0}.", oddTotal);

            /*
                -TEST VALUES-
                Array 1: 1,2,3,4,5,6,7,8,9,10,11,12
                Odd Array: 1,0,3,0,5,0,7,0,9,0,11,0
                Total: 36
            */




            // Question 4: RPG Battle!
            Console.WriteLine("Question 4");

            // Declare fighter values
            string blackHat = "Black Hat Hacker";
            string whiteHat = "White Hat Hacker";
            int blackHealth = 100;
            int whiteHealth = 100;

            // Declare random number
            Random rando = new Random();

            // Set Boolean to validate while
            Boolean fight = true;

            // While loop of fight
            while (fight == true)
            {
                // Hit damage
                int roundDamageBlack = rando.Next(0, 10);
                int roundDamageWhite = rando.Next(0, 10);

                // Update fighter health
                blackHealth = blackHealth - roundDamageBlack;
                whiteHealth = whiteHealth - roundDamageWhite;

                // Check if any figher is at zero health
                if (blackHealth <= 0 && whiteHealth <= 0)
                {
                    // They both died
                    Console.WriteLine("They both died in battle! There will now be WAR!");

                    // Update fight Boolean
                    fight = false;
                } 
                else if (blackHealth <= 0 || whiteHealth <= 0)
                {
                    // Determine who died
                    if (blackHealth <= 0)
                    {
                        // White Hat won
                        Console.WriteLine("The {0} won!", whiteHat);
                    }
                    else
                    {
                        // Black Hat won
                        Console.WriteLine("The {0} won!", blackHat);
                    }

                    // Update fight Boolean
                    fight = false;
                }
                else
                {
                    // Continue fighting! Announce round results
                    Console.WriteLine("After attack: {0} hp: {1}, {2} hp: {3}.", blackHat, blackHealth, whiteHat, whiteHealth);
                }

            }

            /*
               -TEST VALUES-
               Values are randomly generated
            */

        }
    }
}
