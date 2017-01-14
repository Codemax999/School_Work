using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    //derives members from Weapon, including Equip from IEquippable
    class RangedWeapon : Weapon
    {
        //primitive member variable
        double range;

        //default constructor
        public RangedWeapon()
        {
            range = 0.0;
        }

        //constructor to set values and call the base class constructor
        public RangedWeapon(int setAttack, string setName, double setRange) : base(setAttack, setName)
        {
            range = setRange;
        }

        //access range
        public double Range
        {
            get { return range; }
            set { range = value; }
        }

        //display information about this melee weapon, uses the Weapon's display status for displaying inherited values
        //the new keyword is used to hide the base class method so that only this version of the method can be used from a RangedWeapon
        override public void DisplayStatus()
        {
            base.DisplayStatus();
            Console.WriteLine("Range: " + Range);
        }
    }
}
