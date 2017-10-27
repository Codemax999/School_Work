using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_StringObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Cody Maxwell
                07/23/2016
                MDV2330-O
                Assignment: String Object
            */

            /* 
             For	each	problem	below you	will	need	the	following:
                • Create	a	new	project	with	a	main()	method	that	can	call	other	methods.	
                • Label	the	section	of	code	appropriately.
                • Create	a	method	for	each	of	the	(2)	problems and	call them	from	the	main()	method.
                • All	of	the	problems	involve	String	objects,	so	use	String	methods	to	solve	them.	
                • Do	additional	research	on	String methods	as	there	may	be	some	useful	methods	that	
                were	not	covered	in	class.	
                • You	don't	have	to	use	a	ReadLine()	to	gather	input	for	the	required	values.	 You	can	
                hard-code	these	as	literals	in	the	Main()	method,	and	then	pass	those	values	into	the	
                methods	during	the	method	call.
                • When	complete,	compress the	files	into	a	Zip	and	upload	the	zipped	file	to	FSO.
             
             */


            // Problem 1: Email Address Checker
            Console.WriteLine("PROBLEM 1");

            // Declare email variable
            string userEmail = "CEMaxwell@fullsail.edu";

            // Pass email to function to check validity
            string emailTest = CheckEmail(userEmail);

            // Print out email address to user
            Console.WriteLine("The email that you have provided is {0}.", emailTest);


            // Problem 2: Separator Swap Out
            Console.WriteLine("PROBLEM 2");

            // Declar String variables to be passed as parameters
            string listOfLetters = "a,b,c,d";
            string firstSeparator = ",";
            string secondSeparator = "/";

            // Call function and pass in parameters
            string newList = SwapOut(listOfLetters, firstSeparator, secondSeparator);

            // Print out new string to user
            Console.WriteLine("The new string with a separator of {0} is {1}.", secondSeparator, newList);
        }

        // Email validating function
        public static string CheckEmail(string email)
        {

            // Remove spaces from start and end of string
            email.Trim();

            // Check to see if email has blank spaces or is missing @ symbol
            if (email.Contains(" ") || !email.Contains("@"))
            {
                // Not a valid email address
                return "not a valid email address";
            }
            else
            {
                // Get index of @ symbol
                int atIndex = email.IndexOf("@");

                // Verify . index is after atIndex
                if (email.IndexOf(".", atIndex) == -1)
                {
                    // Not a valid email address
                    return "not a valid email address";
                }
                else
                {
                    // Email is valid
                    return "a valid email address";
                }
            }
        }

        // String replacing function
        public static string SwapOut(string letters, string first, string second)
        {

            // Replace , for / string
            string newLetters = letters.Replace(first, second);

            // Return new string
            return newLetters;
        }
    }
}
