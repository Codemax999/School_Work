using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindErrorsFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Name: Cody Maxwell
                Date: 07/23/2016
                Section: MDV2330-O
                Find The Errors In Functions
            */

            /*
                In this program we will be asking for 2 prices for the user
                We will ask for the sales tax rate
                Create a function that will return the price + sales tax
                Create a function that will add the 2 prices with sales tax together for the total cost
            */

            Console.WriteLine("Hello and welcome to our purchase calculator!\r\nWe will be asking you for 2 item prices and the sales tax rate.\r\n");

            Console.WriteLine("What is the cost of your first item?");

            string cost1String = Console.ReadLine();

            decimal cost1;

            while (!decimal.TryParse(cost1String, out cost1))
            {
                Console.WriteLine("Please only type in numbers!\r\nWhat is the cost of your first item?");

                cost1String = Console.ReadLine();

            }


            Console.WriteLine("What is the cost of your second item?");

            string cost2String = Console.ReadLine();

            decimal cost2;

            while (!decimal.TryParse(cost2String, out cost2))
            {
                Console.WriteLine("Please only type in numbers!\r\nWhat is the cost of your second item?");

                cost2String = Console.ReadLine();

            }


            Console.WriteLine("What is the sales tax rate %?");

            string salestaxString = Console.ReadLine();

            int salesTax;

            while (!int.TryParse(salestaxString, out salesTax))
            {
                Console.WriteLine("Please only type in numbers!\r\nWhat is the sales tax rate in %?");

                salestaxString = Console.ReadLine();

            }

            Console.WriteLine("I have all the information I need.\r\nYour first item costs {0}.\r\nYour second item costs {1} and the sales tax is {2}%.", cost1, cost2, salesTax);

            decimal cost1WithTax = AddSalesTax(cost1, salesTax);
            decimal cost2WithTax = AddSalesTax(cost2, salesTax);

            decimal grandTotal = TotalCosts(cost1WithTax, cost2WithTax);

            Console.WriteLine("\r\nWith tax your first item costs {0}.\r\nYour second item costs {1}.", cost1WithTax.ToString("C"), cost2WithTax.ToString("C"));
            Console.WriteLine("\r\nWhich makes the total for your bill {0}", grandTotal.ToString("C"));

        }

        public static decimal AddSalesTax(decimal price, decimal tax)
        {

            decimal calculateTax = price * (tax / 100);
            decimal totalWithTax = price + calculateTax;
            return totalWithTax;

        }

        public static decimal TotalCosts(decimal cost1, decimal cost2)
        {
            decimal total = cost1 + cost2;
            return total;

        }


        /* 
            -TEST VALUES-
            Cost 1: 10
            Cost 2: 10
            Tax %: 6
            Total 1: 10.60
            Total 2: 10.60
            Full Total: 21.20
        */

    }
}
