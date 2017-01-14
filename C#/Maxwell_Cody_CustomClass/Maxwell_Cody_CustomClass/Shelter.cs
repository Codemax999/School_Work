using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_CustomClass
{
    class Shelter
    {
        // Member Variables
        int mDogsMax;
        int mDogsMin;
        int mDogsCurrent;

        // Constructor 
        public Shelter(int _dogsMax, int _dogsMin, int _dogsCurrent)
        {
            // Assign values to member variables
            mDogsMax = _dogsMax;
            mDogsMin = _dogsMin;
            mDogsCurrent = _dogsCurrent;
        }

        // Getters
        public int GetMax()
        {
            // Return max dogs
            return mDogsMax;
        }

        public int GetMin()
        {
            // Return min dogs
            return mDogsMin;
        }

        public int GetCurrent()
        {
            // Return current dogs
            return mDogsCurrent;
        }

        // Setters
        public void SetMax(int _dogsMax)
        {
            // Update max dog value
            this.mDogsMax = _dogsMax;
        }

        public void SetMin(int _dogsMin)
        {
            // Update min dog values
            this.mDogsMin = _dogsMin;
        }

        public void SetCurrent(int _dogsCurrent)
        {
            // Update current dog values
            this.mDogsCurrent = _dogsCurrent;
        }

        // Custom Function
       public int UpdateDogs(string _type, int _dogsCurrent, int _dogsMax, int _dogsChange)
        {
            // If statement to determine whether this number will exceed max dogs or fall below zero
            if (_type.ToLower().Trim() == "increase")
            {
                // Add current dogs to user num response
                int dogTotal = _dogsCurrent + _dogsChange;

                // Check to see if dog total exceeds max dogs
                if (dogTotal > _dogsMax)
                {
                    // Alert user error
                    Console.WriteLine("There is not enough room for {0} dogs. The max amount is {1}.", _dogsChange, _dogsMax);

                    // Return previous dog total
                    return _dogsCurrent;
                }
                else
                {
                    // Return dog total
                    return dogTotal;
                }
            }
            else 
            {
                // Subtract current dogs from user num to see if it falls below dog minimum
                int dogTotal = _dogsCurrent - _dogsChange;

                // if statement to see if dogTotal falls below minDogs or 0
                if (dogTotal < 0)
                {
                    // Alert user of error
                    Console.WriteLine("{0} dogs can not be removed, because it is falls below 0.", _dogsChange);

                    // Return previous dog total
                    return _dogsCurrent;
                }
                else
                {
                    // Return dog total
                    return dogTotal;
                }

            }
        }
    }
}
