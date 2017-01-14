using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    //derives from MeleeWeapon, which includes Weapon, which also include IEquippable
    class Sword : MeleeWeapon
    {
        //primitive member variable
        int sharpness;

        //default constructor
        public Sword()
        {
            Sharpness = 0;
        }

        //constructor that sets values and calls the base constructor from MeleeWeapon, which then calls the base Weapon Constructor
        Sword(int setAttack, string setName, double setReach, int setSharpness) : base(setAttack, setName, setReach)
        {
            sharpness = setSharpness;
        }

        //access sharpness
        public int Sharpness
        {
            get { return sharpness; }
            set { sharpness = value; }
        }

        //display information about this melee weapon, uses the MeleeWeapon's and Weapon's display status for displaying inherited values
        //the new keyword is used to hide the base class method so that only this version of the method can be used from a Sword
        override public void DisplayStatus()
        {
            base.DisplayStatus();
            Console.WriteLine("Sharpness: " + Sharpness);
        }
    }
}
