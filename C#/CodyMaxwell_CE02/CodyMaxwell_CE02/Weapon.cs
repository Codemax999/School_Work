using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE02
{
    class Weapon
    {
        //member variables
        int mAttack;
        string mWeaponName;

        //default constructor
        public Weapon(int _attack, string _weaponName)
        {
            //assign to member variables
            mAttack = _attack;
            mWeaponName = _weaponName;
        }

        //getter and setter: attack
        public int Attack
        {
            get { return mAttack; }
            set { mAttack = value; }
        }

        //getter and setter: weapon name
        public string WeaponName
        {
            get { return mWeaponName; }
            set { mWeaponName = value; }
        }
    }
}
