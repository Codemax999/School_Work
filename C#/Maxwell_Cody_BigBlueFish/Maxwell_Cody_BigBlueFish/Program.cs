using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_BigBlueFish
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Cody Maxwell
                07/17/2016
                Assignment: Biggest Blue Fish
                Scalable Data Infrastructures
            */


            // Declare fish color and length arrays
            string[] fishColor = new string[] { "red", "blue", "green", "yellow", "red", "blue", "green", "yellow", "red", "blue", "green", "yellow", };
            int[] fishLength = new int[] { 22, 1, 23, 41, 16, 14, 33, 51, 9, 35, 2, 12 };

            // Create answer validation boolean
            Boolean selectFish = true;

            // While loop for fish validation
            while (selectFish == true)
            {
                // Ask user to select fish based on color
                Console.WriteLine("Select a fish, choose (1) for Red (2) for Blue (3) for Green or (4) for yellow.");

                // Get users response
                string fishSelection = Console.ReadLine();

                // Declare int to store user selection
                int selectionNum = 0;

                // Validate response for number 
                if (int.TryParse(fishSelection, out selectionNum))
                {
                    // Validate that number is between 1 and 4
                    if (selectionNum < 1 || selectionNum > 4)
                    {
                        // Not a valid number 
                        Console.WriteLine("Please only enter a valid number.");
                    }
                    else
                    {
                        // Declare string for fish color
                        string fishSelectionColor = "";

                        // Update fishSectionColor based on selectionNum
                        if (selectionNum == 1)
                        {
                            // Fish is red
                            fishSelectionColor = "red";
                        }
                        else if (selectionNum == 2)
                        {
                            // Fish is blue
                            fishSelectionColor = "blue";
                        }
                        else if (selectionNum == 3)
                        {
                            // Fish is green
                            fishSelectionColor = "green";
                        }
                        else
                        {
                            // Fish is yellow
                            fishSelectionColor = "yellow";
                        }

                        // Declare int array to store fish indexes that match color
                        int[] fishIndex = new int[] { 0, 0, 0 };

                        // Loop through fishColor array to find which indexes match 
                        for (int i = 0; i < fishColor.Length; i++)
                        {
                            // if color is a match
                            if (fishColor[i] == fishSelectionColor)
                            {
                                // Set fishIndex index values
                                if (i < 4)
                                {
                                    // Update first array index
                                    fishIndex[0] = i;
                                }
                                else if (i < 8)
                                {
                                    // Update second array index
                                    fishIndex[1] = i;
                                }
                                else
                                {
                                    // Update third array index
                                    fishIndex[2] = i;
                                }
                            }
                        }

                        // Declare variables for fishIndex indexes
                        int indexOne = fishIndex[0];
                        int indexTwo = fishIndex[1];
                        int indexThree = fishIndex[2];
                        
                        // Get values from fish length array based on fishIndex value
                        int lengthOne = fishLength[indexOne];
                        int lengthTwo = fishLength[indexTwo];
                        int lengthThree = fishLength[indexThree];

                        // Compare fish lengths
                        if (lengthOne > lengthTwo && lengthOne > lengthThree)
                        {
                            // Length one is your fish
                            Console.WriteLine("Fish {0} is your fish. It is {1} and {2} feet long.", indexOne, fishSelectionColor, lengthOne);
                        }
                        else if (lengthTwo > lengthOne && lengthTwo > lengthThree)
                        {
                            // Length two is your fish
                            Console.WriteLine("Fish {0} is your fish. It is {1} and {2} feet long.", indexTwo, fishSelectionColor, lengthTwo);
                        }
                        else
                        {
                            // Length three is your fish
                            Console.WriteLine("Fish {0} is your fish. It is {1} and {2} feet long.", indexThree, fishSelectionColor, lengthThree);
                        }

                        // End whie loop
                        selectFish = false;
                    }
                }
                else if (string.IsNullOrWhiteSpace(fishSelection))
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
                -Test Values-
                Select (1) : Index 8, Red, 9
            */
        }
    }
}
