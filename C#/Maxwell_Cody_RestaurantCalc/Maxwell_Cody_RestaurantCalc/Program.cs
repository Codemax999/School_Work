using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_RestaurantCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
 Cody Maxwell
 07/03/2016
 SDI MDV2330
 Assignment: Tip Calculator
*/

            // Individual meal and tip variables
            string mealOneStr = "";
            string mealTwoStr = "";
            string mealThreeStr = "";
            string tipPercentStr = "";

            // Ask guest one for meal one cost
            Console.WriteLine("Please enter the cost of the first meal: ");
            mealOneStr = Console.ReadLine();

            // Convert meal one string to decimal
            decimal mealOneDec = decimal.Parse(mealOneStr);

            // Ask guest two for meal two cost
            Console.WriteLine("Meal one cost $" + mealOneDec + ". Please enter the cost of the second meal: ");
            mealTwoStr = Console.ReadLine();

            // Covert meal two string to decimal
            decimal mealTwoDec = decimal.Parse(mealTwoStr);

            // Ask guest three for meal three cost
            Console.WriteLine("Meal two cost $" + mealTwoDec + ". Please enter the cost of the third meal: ");
            mealThreeStr = Console.ReadLine();

            // Convert meal three string into decimal
            decimal mealThreeDec = decimal.Parse(mealThreeStr);

            // Print out the total for all meals without tip
            decimal mealTotalNoTip = mealOneDec + mealTwoDec + mealThreeDec;
            Console.WriteLine("Your meal total is $" + mealTotalNoTip + ". Please enter the percent tip you would like to leave: ");

            // Get meal tip percent amount
            tipPercentStr = Console.ReadLine();

            // Convert meal tip percent string into decimal
            decimal tipPercentDec = decimal.Parse(tipPercentStr);

            // Calculate meal tip
            decimal tipTotal = tipPercentDec * mealTotalNoTip / 100;

            // Calculate meal total with tip
            decimal mealTotal = mealTotalNoTip + tipTotal;

            // Calculate each guests cost
            decimal eachGuest = mealTotal / 3;

            // Print out meal total with tip included and how much each guest owes
            Console.WriteLine("Your meal total with tip is $" + mealTotal + ". Each guest owes $" + eachGuest + ".");
        }
    }
}
