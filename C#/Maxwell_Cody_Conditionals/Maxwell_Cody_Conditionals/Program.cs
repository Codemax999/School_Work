using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
               Cody Maxwell
               07/14/2016
               MDV2330-O
               Scalable Data Infrastructures
               Assignment: Conditionals
             */

            // QUESTION 1: Celsius to Fahrenheit Converter
            Console.WriteLine("QUESTION 1");

            // Declare variable initial values
            double degree = 0;
            string unit = "";

            // Set a Boolean checkers to validate when code should move on
            Boolean degreeChecker = false;
            Boolean unitChecker = false;

            // Set while loop based on truthiness of degreeChecker
            while (degreeChecker == false)
            {

                // Ask user for degree amount
                Console.WriteLine("Enter a degree to be converted: ");

                // Validate to make sure a number was entered
                string degreeStr = Console.ReadLine();

                // Set do while loop to continue question until validated number is entered
                if (double.TryParse(degreeStr, out degree))
                {

                    // Update degree checker to true
                    degreeChecker = true;

                }
                else if (string.IsNullOrWhiteSpace(degreeStr))
                {

                    // Nothing entered
                    Console.WriteLine("Please do need leave this blank.");

                }
                else
                {

                    // Not a number
                    Console.WriteLine("Please enter a valid number.");

                }
            }

            // Display successful number to user
            string numberSuccess = string.Format("You have entered {0}.", degree);
            Console.WriteLine(numberSuccess);

            // Set while loop based on truthiness of unitChecker 
            while (unitChecker == false)
            {

                // Ask user for conversion type
                Console.WriteLine("Please enter capital C to convert to Celsius or capital F to convert to Fahrenheit.");

                // User response
                string unitString = Console.ReadLine();

                // if C or F is entered, update unit string and change unitChecker
                if (unitString == "C" || unitString == "F")
                {

                    // Update unit variable
                    unit = unitString;

                    // Change truthiness of unitChecker
                    unitChecker = true;

                }
                else if (string.IsNullOrWhiteSpace(unitString))
                {

                    // Nothing entered 
                    Console.WriteLine("Do not leave this blank.");

                } 
                else
                {

                    // Something other than C or F was entered
                    Console.WriteLine("Only enter a capital C or capital F.");

                }
            }

            // Converted temperature variables
            double convertedTemp = 0;
            string finalUnit = "";

            // Take degree amount and convert it based on unit type
            if (unit == "C")
            {

                // Convert to Celsius
                double convertStepOne = degree - 32;
                convertedTemp = convertStepOne * .5556;
                finalUnit = "Celsius";

            } 
            else
            {

                // Convert to Fahrenheit
                convertedTemp = degree * 1.8 + 32;
                finalUnit = "Fahrenheit";

            }

            // Print out the converted temperature to the user
            string displayTemp = string.Format("The temperature is {0} degrees {1}.", convertedTemp, finalUnit);
            Console.WriteLine(displayTemp);

            /*
                 -Test Values-
                 Degree: 63
                 Convert to: Celsius
                 Calculation: 17.2236 degrees Celsius                       

             */




            // Question 2: Last Chance for Gas
            Console.WriteLine("QUESTION 2");

            // Set initial variables for car readings and distance to next station
            double mpg = 0;
            double remainingGas = 0;
            double tankCapacity = 0;
            double nextStation = 200;

            // Set Boolean truthiness testers
            Boolean mpgTest = false;
            Boolean remainingTest = false;
            Boolean capacityTest = false;

            // While loop until mpg question passes validation
            while (mpgTest == false)
            {

                // Ask user to enter cars mpg
                Console.WriteLine("How many miles per gallon does this car get?");

                // Users response
                string response = Console.ReadLine();

                // If passes, update mpg variable and chage mpgTest truthiness
                if (double.TryParse(response, out mpg))
                {

                    // Change truthiness of mpgTest to move on
                    mpgTest = true;

                }
                else if (string.IsNullOrWhiteSpace(response))
                {

                    // Nothing entered 
                    Console.WriteLine("Please do not leave this blank.");

                }
                else
                {

                    // Not a number
                    Console.WriteLine("Please only enter a valid number");

                }
            }

            // While loop until remaining gas question passes validation
            while (remainingTest == false)
            {

                // Ask user for remaing percent of gas left in tank
                Console.WriteLine("What percent do you have in remaining fuel?");

                // Users response
                string response = Console.ReadLine();

                // If passes, update remainingGas variable and change truthiness of remainingTest
                if (double.TryParse(response, out remainingGas))
                {

                    // Change truthiness of remainingTest
                    remainingTest = true;

                } 
                else if (string.IsNullOrWhiteSpace(response))
                {

                    // Nothing entered
                    Console.WriteLine("Please do not leave this blank.");

                }
                else
                {

                    // Something other than a number entered
                    Console.WriteLine("Please only enter valid numbers");

                }
            }

            // While loop until gas tank capacity question passes validation
            while (capacityTest == false)
            {

                // Ask user for gas tank capacity
                Console.WriteLine("How many gallons of gas can your car hold?");

                // User response
                string response = Console.ReadLine();

                // If response passes, update tankCapacity variable
                if (double.TryParse(response, out tankCapacity))
                {

                    // Update capacityTest truthiness
                    capacityTest = true;

                }
                else if (string.IsNullOrWhiteSpace(response))
                {

                    // Nothing entered
                    Console.WriteLine("Please do not leave this blank.");

                } 
                else
                {

                    // Not a valid number
                    Console.WriteLine("Please only enter valid numbers.");

                }
            }

            // Calculate how many gallons left in the tank
            double remainingGallons = remainingGas * tankCapacity / 100;

            // Calculate how many more miles until empty
            double milesTillEmpty = remainingGallons * mpg;

            // if milesTillEmpty is less than the distance to the next station, warn the user
            if (milesTillEmpty < nextStation)
            {

                // Warn the user that they will not make it
                string warning = string.Format("You only have {0} gallons of gas in your tank, better get gas now while you can!", remainingGallons);
                Console.WriteLine(warning);

            }
            else
            {

                // Let the user know they can make it to the next station
                Console.WriteLine("Yes, you can make it without stopping for gas!");

            }

            /*
                 -Test Values-
                 MPG: 28
                 % Remaining in tank: 30
                 Tank capacity: 16 gallons
                 Remaing Fuel: 4.8 gallins (need gas)                      

             */




            // Question 3: Grade Letter Calculation
            Console.WriteLine("QUESTION 3");

            // Declare students grade variables
            int grade = 0;
            string letter = "";

            // Boolean to handle while loop for input validation
            Boolean gradeCheck = false;

            // While loop to validate user input
            while (gradeCheck == false)
            {
                // Ask user to input course grade
                Console.WriteLine("Please enter the percent grade you received in this course.");

                // Get the users response
                var response = Console.ReadLine();

                // If the input passes as an int
                if (int.TryParse(response, out grade))
                {

                    // Make sure number is number between 0 and 100
                    if (grade <= 100 && grade >= 0)
                    {

                        // Assign letter grade based on percent
                        if (grade >= 90)
                        {
                            // Received an A
                            letter = "A";
                        }
                        else if (grade >= 80)
                        {
                            // Received a B
                            letter = "B";
                        }
                        else if (grade >= 70)
                        {
                            // Received a C
                            letter = "C";
                        }
                        else if (grade >= 60)
                        {
                            // Received a D
                            letter = "D";
                        } 
                        else
                        {
                            // Received an F
                            letter = "F";
                        }

                        // Update truthiness of gradeCheck Bool
                        gradeCheck = true;

                    }
                    else
                    {

                        // Number is out of bounds
                        Console.WriteLine("The number needs to be between 0 and 100.");

                    }
                }
                else if (string.IsNullOrWhiteSpace(response))
                {

                    // Nothing entered
                    Console.WriteLine("Do not leave this blank.");

                }
                else
                {

                    // Not a valid number
                    Console.WriteLine("Only enter valid numbers.");

                }
            }

            // Tell the user the letter grade they received
            string userGrade = string.Format("You have a {0}%, which means you have earned a(n) {1} in the class!", grade, letter);
            Console.WriteLine(userGrade);

            /*
                 -Test Values-
                 % Grade Received: 99
                 Letter Grade: A                     

             */



            // Question 4: Check the Login
            Console.WriteLine("QUESTION 4");

            // Declare username and password variables
            string usernameEntered = "";
            string passwordEntered = "";
            string usernameCorrect = "codemax";
            string passwordCorrect = "superSecret";

            // Boolean to hold while loop until validated
            Boolean login = false;

            // While loop until correct username and password is entered
            while (login == false)
            {

                // Ask user for username
                Console.WriteLine("Please enter your username.");

                // User username response
                usernameEntered = Console.ReadLine();

                // Ask user for password
                Console.WriteLine("Please enter your password.");

                // User password response
                passwordEntered = Console.ReadLine();

                // if username and password match, greet the user
                if (usernameEntered == usernameCorrect && passwordEntered == passwordCorrect)
                {

                    // Welcome the user
                    string welcome = string.Format("Welcome, {0}!", usernameCorrect);
                    Console.WriteLine(welcome);

                    // Update truthiness of login
                    login = true;

                }
                else if (usernameEntered != usernameCorrect)
                {

                    // The username entered by the user is incorrect
                    Console.WriteLine("User not found, Try again.");

                } 
                else if (passwordEntered != passwordCorrect)
                {

                    // The password entered by the user is incorrect
                    Console.WriteLine("Password does not match our records.");

                }
            }

            /*
                 -Test Values-
                 username: codemax
                 password: superSecret                     

             */
        }
    }
}
