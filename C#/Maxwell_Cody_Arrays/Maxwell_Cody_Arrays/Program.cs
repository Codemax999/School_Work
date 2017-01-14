using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Cody Maxwell
            MDV233-0
            07/02/2016
            Arrays Assignment
            */

            //Given Number Arrays
            int[] firstArray = new int[4] { 4, 20, 60, 150 };
            double[] secondArray = new double[4] { 5, 40.5, 65.4, 145.98 };

            //Add up array integers for array 1
            int firstArrayTotal = firstArray[0] + firstArray[1] + firstArray[2] + firstArray[3];

            //Print out array total for array 1
            Console.WriteLine("The total for firstArray is " + firstArrayTotal + ".");

            //Add up array integers for array 2
            double secondArrayTotal = secondArray[0] + secondArray[1] + secondArray[2] + secondArray[3];

            //Print out array total for array 2
            Console.WriteLine("The total for secondArray is " + secondArrayTotal + ".");

            //Calculate the average of array 1
            int firstArrayAverage = firstArrayTotal / 4;

            //Print out array average for array 1
            Console.WriteLine("The average for firstArray is " + firstArrayAverage + ".");

            //Calculate the average of array 2
            double secondArrayAverage = secondArrayTotal / 4;

            //Print out array average for array 2
            Console.WriteLine("The average for secondArray is " + secondArrayAverage + ".");


            /*
                Add corresponding array indexes together and create new array with sums
                - Would probably be better done by looping over the array, but 
                this was not covered, I will hard code the values.
                - Also would be better to convert array to double array, but this 
                was not covered, so I will hard code one by one.
                - Convert int to double for calculating.
            */

            //Convert integers to doubles from first array
            double indexOneArrayOne = Convert.ToDouble(firstArray[0]);
            double indexTwoArrayOne = Convert.ToDouble(firstArray[1]);
            double indexThreeArrayOne = Convert.ToDouble(firstArray[2]);
            double indexFourArrayOne = Convert.ToDouble(firstArray[3]);

            //Add first array converted doubles to second array doubles for third array total
            double indexOneArrayThree = indexOneArrayOne + secondArray[0];
            double indexTwoArrayThree = indexTwoArrayOne + secondArray[1];
            double indexThreeArrayThree = indexThreeArrayOne + secondArray[2];
            double indexFourArrayThree = indexFourArrayOne + secondArray[3];

            //Create new double array 
            double[] thirdArray = new double[4] { indexOneArrayThree, indexTwoArrayThree, indexThreeArrayThree, indexFourArrayThree };

            //Print out the third array
            Console.WriteLine("The third array is " + thirdArray[0] + ", " + thirdArray[1] + ", " + thirdArray[2] + ", " + thirdArray[3] + ".");


            //Given String Array
            string[] MixedUp = new string[] { "but the lighting of a", "Education is not", "fire.", "the filling", "of a bucket," };

            //Concatenate array strings together into single string
            string fullSentence = MixedUp[1] + " " + MixedUp[3] + " " + MixedUp[4] + " " + MixedUp[0] + " " + MixedUp[2];

            //Print out full sentence string
            Console.WriteLine(fullSentence);

        }
    }
}
