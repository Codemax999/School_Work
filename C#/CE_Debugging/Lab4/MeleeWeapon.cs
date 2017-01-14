using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    //base class of Weapon, includes interface IEquippable
    class MeleeWeapon : Weapon
    {
        //primitive type member
        double reach;

        //default constructor
        public MeleeWeapon()
        {
            reach = 0.0;
        }

        //constructor to set all member values, calls specific base class constructor in this case Weapon's constructor
        public MeleeWeapon(int setAttack, string setName, double setReach) : base(setAttack, setName)
        {
            reach = setReach;
        }

        //access reach
        public double Reach
        {
            get { return reach; }
            set { reach = value; }
        }

        //display information about this melee weapon, uses the Weapon's display status for displaying inherited values
        //the new keyword is used to hide the base class method so that only this version of the method can be used from a MeleeWeapon
        override public void DisplayStatus()
        {
            base.DisplayStatus();
            Console.WriteLine("Reach: " + Reach);
        }
    }
}
