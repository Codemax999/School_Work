using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Maxwell_Cody_ArrayLists
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Cody Maxwell
                07/24/2016
                MDV2330-O
                Assignment: ArrayLists
            */

            // Method call to begin program
            Begin();
        }

        public static void Begin()
        {
            // Declare values of ArrayList for related items
            ArrayList familyMembers = new ArrayList() { "Mother", "Father", "Brother", "Sister" };

            // Declare values of ArrayList for job titles corresponding to family members
            ArrayList familyJobs = new ArrayList() { "Teacher", "Helicopter Inspector", "Pilot", "Entrepreneur" };

            // For loop to go through ArrayList
            for (int i = 0; i < familyMembers.Count; i++)
            {
                // Print out family member and job title
                Console.WriteLine("My {0} is a {1}.", familyMembers[i], familyJobs[i]);
            }

            // Sort both ArrayLists alphabetically
            familyMembers.Sort();
            familyJobs.Sort();

            // Reverse both ArrayLists 
            familyMembers.Reverse();
            familyJobs.Reverse();

            // For loop to print out new family member job titles
            for (int i = 0; i < familyMembers.Count; i++)
            {
                // Print out results to console
                Console.WriteLine("Now my {0} is a {1}.", familyMembers[i], familyJobs[i]);
            }
        }
    }
}
    