using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    class Character
    {
        //member variables
        private string mName;
        private int mBaseAttack;

        //member class object
        private Weapon mCurrentWeapon;

        //member list of equippables
        private List<IEquippable> mEquippables = new List<IEquippable>();

        //member dictionary with string keys and Armor values
        private Dictionary<string, Armor> mArmors = new Dictionary<string, Armor>();

        //empty constructor 
        public Character()
        {

        }

        //default character constructor 
        public Character(string _name, int _baseAttack)
        {
            mName = _name;
            mBaseAttack = _baseAttack;
        }

        //get set name
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        //get set base attack
        public int BaseAttack
        {
            get { return mBaseAttack; }
            set { mBaseAttack = value; }
        }

        //get set current weapon
        public Weapon CurrentWeapon
        {
            get { return mCurrentWeapon; }
            set { mCurrentWeapon = value; }
        }

        //get set list of equipables
        public List<IEquippable> Equippables
        {
            get { return mEquippables; }
            set { mEquippables = value; }
        }

        //get set current gear dictionary
        public Dictionary<string, Armor> Armors
        {
            get { return mArmors; }
            set { mArmors = value; }
        }

        //method to display equippables 

        //method to display Armor and values
    }
}
