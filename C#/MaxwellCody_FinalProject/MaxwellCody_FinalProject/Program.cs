using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxwellCody_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Cody Maxwell
                Scalable Data Infrastructures
                MDV2330-O
                Final Project
                Practical Exam
            */

            // Ask user to enter a sentence 
            Console.WriteLine("Please enter any sentence.");

            // Get users response
            string userResponse = Console.ReadLine();

            // Pass string argument to Capitalize function
            string sentenceCap = Capitalize(userResponse);

            // Print out updated capitalized string to use
            Console.WriteLine(sentenceCap);

        }

        public static string Capitalize(string sentence)
        {
            // Create variable to help avoid lowercasing first letters
            int protectCaps = 0;

            // for loop to go through string and upper case first letter of each word
            for (int i = 0; i < sentence.Length; i++)
            {
                 // if index is 0
                if (i == 0)
                {
                    // Convert char to string and uppercase
                    string firstCap = sentence[i].ToString().ToUpper();

                    // Remove lowercase and insert uppercase
                    sentence = sentence.Remove(0, 1).Insert(0, firstCap);
                }
                else if (sentence[i].ToString() == " ")
                {
                    // Get next index value
                    int nextValue = i + 1;

                    // Update protectCaps to avoid lowercasing the letter
                    protectCaps = nextValue;

                    // Convert char to string and uppercase 
                    string nextCap = sentence[nextValue].ToString().ToUpper();

                    // Remove current and insert uppercase
                    sentence = sentence.Remove(nextValue, 1).Insert(nextValue, nextCap);
                } 
                else if (i != protectCaps)
                {
                    // Convert char to string and lowercase
                    string nextLower = sentence[i].ToString().ToLower();

                    // Remove current and insert lowercase
                    sentence = sentence.Remove(i, 1).Insert(i, nextLower);
                }
            }

            // for loop to go through string and make sure all other letters are lowercase
            return sentence;
        }
    }
}
