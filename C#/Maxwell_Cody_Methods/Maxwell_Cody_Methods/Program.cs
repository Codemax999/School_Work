using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_Methods
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Cody Maxwell
                07/22/2016
                MDV2330-O
                Assingment: Methods
            */

            /*
                For	each	problem	below you	will	need	the	following:
                    • Label	the	section	of	code	appropriately.
                    • Create	a	method	for	each	of	the	(3)	problems.
                    • Write	the	givens	as	variables	that	are	collected	from	a	user	prompt	inside	of	the
                    appropriate	method.
                    • Validate	and	convert	each	user	prompt to	insure	that	the	user	is	typing	in	a	valid
                    response.
                    • The	result	should	be	calculated	using	a	variable	and	returned	to	the	main	code.
                    • Print	out	the	result	of	each	function	to	the	console	in	the	main	code.
                    • Use	only	code	and	techniques	learned	in	this	class.
            */



            // Problem 1: Circumference 
            Console.WriteLine("QUESTION 1");

            // Declare variables for user input
            double radius;
            double pi = Math.PI;

            // Ask User to enter value of radius
            Console.WriteLine("Please enter the radius of the circle.");

            // Get user response
            string responseRadius = Console.ReadLine();

            // Validate user response with while loop to make sure valid number is entered
            while (!double.TryParse(responseRadius, out radius))
            {
                // Response is not valid
                Console.WriteLine("Only enter vaild numbers.\r\nPlease enter the radius of the circle.");

                // Ask for user input again
                responseRadius = Console.ReadLine();

            }

            // Pass radius and pi to function
            double circumference = CalculateCirc(radius, pi);

            // Print out calculated circumference to user
            Console.WriteLine("The circumference of the circle is {0}.", circumference);



            // Problem 2: Stung!
            Console.WriteLine("QUESTION 2");

            // Declare variable for victim weight
            double victimWeight;

            // Ask user to give users weight
            Console.WriteLine("Please enter the weight of the animal.");

            // Get user response
            string responseWeight = Console.ReadLine();

            // Validate user response with while loop to make sure valid number is entered
            while (!double.TryParse(responseWeight, out victimWeight))
            {
                // Response is not valid
                Console.WriteLine("Only enter valid numbers.\r\nPlease enter the weight of the animal.");

                // Ask for user input again
                responseWeight = Console.ReadLine();

            }

            // Pass animal weight to function
            double stingCounter = CalculateStings(victimWeight);

            // Print out response to the user
            Console.WriteLine("It takes {0} bee stings to kill this animal.", stingCounter);



            // Problem 3: Reverse It
            Console.WriteLine("QUESTION 3");

            // Declare array to be reversed
            int[] numbers = new int[] { 0, 1, 2, 3, 4 };

            // Pass array to function to be reversed
            int[] reverseNum = Reverse(numbers);

            // Print out original and reversed array
            Console.WriteLine("Your original array was {0}, {1}, {2}, {3}, {4} and now it is reversed as {5}, {6}, {7}, {8}, {9}.", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], reverseNum[0], reverseNum[1], reverseNum[2], reverseNum[3], reverseNum[4]);

        }

        public static double CalculateCirc(double radius, double pi)
        {
            // Calculate circumference 
            double calculated = 2 * pi * radius;

            // Return calculated value
            return calculated;

        }

        public static double CalculateStings(double weight)
        {
            // Declare variable for bee stings per pound
            double stingsPerPound = 8.666666667;

            // Calculate required stings to bring down this animal
            double stingsToKill = weight * stingsPerPound;

            // Return sting number required to kill
            return stingsToKill;
        }

        public static int[] Reverse(int[] num)
        {
            // Create reversed array
            int[] flip = new int[] { num[4], num[3], num[2], num[1], num[0] };

            // Return reverserd array
            return flip;
        }

        /*
            
            -TEST VALUES-

            QUESTION 1
            Radius: 3
            Circumference: 18.8495559215388

            QUESTION 2
            Victim Weight: 100
            Bee Stings Needed: 866.6666667

            QUESTION 3
            Original Array: 0, 1, 2, 3, 4
            Reversed Array: 4, 3, 2, 1, 0

        */
    }
}
