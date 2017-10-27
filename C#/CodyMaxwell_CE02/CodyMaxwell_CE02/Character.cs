using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE02
{
    class Character
    {
        //member variables
        string mName;
        int mBaseAttack;
        int mHealth;
        string mRole;
        int mLevel;

        //member class variable
        Weapon mEquippedWeapon;

        //default constructor
        public Character()
        {
            //empty
        }

        //contstructor with no weapon
        public Character(string _name, int _baseAttack, int _health, string _role, int _level)
        {
            //assign to member variables
            mName = _name;
            mBaseAttack = _baseAttack;
            mHealth = _health;
            mRole = _role;
            mLevel = _level;
        }

        //constructor with weapon
        public Character(string _name, int _baseAttack, int _health, string _role, int _level, Weapon _equippedWeapon)
        {
            //assign to member variables
            mName = _name;
            mBaseAttack = _baseAttack;
            mHealth = _health;
            mRole = _role;
            mLevel = _level;
            mEquippedWeapon = _equippedWeapon;
        }

        //getter and setter: name
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        //getter and setter: base attack
        public int BaseAttack
        {
            get { return mBaseAttack; }
            set { mBaseAttack = value; }
        }

        //getter and setter: health
        public int Health
        {
            get { return mHealth; }
            set { mHealth = value; }
        }

        //getter and setter: position
        public string Role
        {
            get { return mRole; }
            set { mRole = value; }
        }

        //getter and setter: in battle
        public int Level
        {
            get { return mLevel; }
            set { mLevel = value; }
        }

        //getter and setter: equipped weapon
        public Weapon EquippedWeapon
        {
            get { return mEquippedWeapon; }
            set { mEquippedWeapon = value; }
        }
    }
}
