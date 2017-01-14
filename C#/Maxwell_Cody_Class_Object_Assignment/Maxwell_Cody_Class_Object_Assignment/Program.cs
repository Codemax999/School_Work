using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_Class_Object_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Cody Maxwell
                11-21-2016
                Rearch 00: Class and Object Basics
            */

            // Greet the user
            Console.WriteLine("Hello and welcome.\r\nPlease enter your aircrafts information.");

            // Boolean to validate if user wants to continue using program
            bool endProgram = false;

            // Loop to rerun program until user ends
            while (endProgram == false)
            {
                // Ask for airplane make
                Console.WriteLine("Please enter the airplane make:");

                // capture user response
                string planeMake = Console.ReadLine();

                // loop until response
                while (String.IsNullOrWhiteSpace(planeMake))
                {
                    // alert user enter valid input
                    Console.WriteLine("Do not leave this blank.\r\nPlease enter your airplane make:");

                    // capture new response 
                    planeMake = Console.ReadLine();
                }

                // Ask for airplane model
                Console.WriteLine("Please enter the airplane model:");

                // capture user response
                string planeModel = Console.ReadLine();

                // loop until response
                while (String.IsNullOrWhiteSpace(planeModel))
                {
                    // alert user enter valid input
                    Console.WriteLine("Do not leave this blank.\r\nPlease enter your airplane model:");

                    // capture new response 
                    planeModel = Console.ReadLine();
                }

                // Ask for airplane color
                Console.WriteLine("Please enter the airplane color:");

                // capture user response
                string planeColor = Console.ReadLine();

                // loop until response
                while (String.IsNullOrWhiteSpace(planeColor))
                {
                    // alert user enter valid input
                    Console.WriteLine("Do not leave this blank.\r\nPlease enter your airplane color:");

                    // capture new response 
                    planeColor = Console.ReadLine();
                }

                // Ask for airplane build year
                Console.WriteLine("Please enter the airplane build year:");

                // capture user response
                string planeYear = Console.ReadLine();
                int planeYearInt;

                // loop until response
                while (!int.TryParse(planeYear, out planeYearInt))
                {
                    // alert user enter valid input
                    Console.WriteLine("Only enter a valid year.\r\nPlease enter your airplane build year:");

                    // capture new response 
                    planeYear = Console.ReadLine();
                }

                // Ask if they want to add the mileage
                Console.WriteLine("Would you like to add the aircraft mileage?\r\nPlease enter yes or no:");

                // capture user response
                string mileageSelection = Console.ReadLine();

                // validate for 1 or 2
                while (mileageSelection.ToLower().Trim() != "yes" && mileageSelection.ToLower().Trim() != "no")
                {
                    // alert user enter valid input
                    Console.WriteLine("Please only enter a valid response.\r\nWould you like to add the aircraft mileage?\r\nPlease enter yes or no:");

                    // capture new response
                    mileageSelection = Console.ReadLine();
                }

                // If 1/yes Ask for mileage else 2/no print out details of plane, including years old
                if (mileageSelection == "yes")
                {
                    // Ask for airplane mileage
                    Console.WriteLine("Please enter the airplane mileage:");

                    // capture user response 
                    string planeMileage = Console.ReadLine();
                    double planeMileageDouble;

                    while(!double.TryParse(planeMileage, out planeMileageDouble))
                    {
                        // alert user enter valid input
                        Console.WriteLine("Only enter valid number.\r\nPlease enter the airplane mileage:");

                        // caputre user reponse 
                        planeMileage = Console.ReadLine();
                    }

                    // Create new plane object
                    Airplane newAirplane = new Airplane(planeMake, planeModel, planeColor, planeYearInt, planeMileageDouble);

                    // Print out details to the user
                    Console.WriteLine("The plane make is: {0}", newAirplane.getMake());
                    Console.WriteLine("The plane model is: {0}", newAirplane.getModel());
                    Console.WriteLine("The plane color is: {0}", newAirplane.getColor());
                    Console.WriteLine("The plane has flown: {0} miles", newAirplane.getMileage());
                    Console.WriteLine("The plane was built in {0} making it {1} years old.", newAirplane.getYear(), newAirplane.getPlaneAge());
                }
                else
                {
                    // Create new plane object
                    Airplane newAirplane = new Airplane(planeMake, planeModel, planeColor, planeYearInt);

                    // Pring out details to the user
                    Console.WriteLine("The plane make is: {0}", newAirplane.getMake());
                    Console.WriteLine("The plane model is: {0}", newAirplane.getModel());
                    Console.WriteLine("The plane color is: {0}", newAirplane.getColor());
                    Console.WriteLine("The plane was built in {0} making it {1} years old.", newAirplane.getYear(), newAirplane.getPlaneAge());
                }

                // ask user if they would like to run the program again
                Console.WriteLine("Thank you.\r\nWould you like to run the program again?\r\nPlease enter yes or no:");

                // capture user response
                string endProgramSelection = Console.ReadLine();

                // validate for 1 or 2
                while (endProgramSelection.ToLower().Trim() != "yes" && endProgramSelection.ToLower().Trim() != "no")
                {
                    // alert user enter valid input
                    Console.WriteLine("Please only enter a valid response.\r\nWould you like to run the program again?\r\nPlease enter yes or no.");

                    // capture new response
                    endProgramSelection = Console.ReadLine();
                }

                // if 1: rerun program else end program
                if (endProgramSelection == "yes")
                {
                    // re run
                    endProgram = false;
                }
                else
                {
                    // end
                    endProgram = true;
                }
            }

            // user has selected to end program
            Console.WriteLine("Thank you, goodbye.");

            /* TEST VALUES
                Make: Cessna
                Model: Citation
                Color: White
                Year: 2001
                Mileage: 1234567

                PRINT OUT
                The plane make is: Cessna
                The plane model is: Citation
                The plane color is: White
                The plane has flown 1234567 miles
                The plane was built in 2001 and is 15 years old
            */
        }
    }
}
