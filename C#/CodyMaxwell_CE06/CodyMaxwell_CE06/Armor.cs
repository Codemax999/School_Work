using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    abstract class Armor : IEquippable
    {
        //member variables
        private int mDefense;

        //constructor
        public Armor(int _defense)
        {
            mDefense = _defense;
        }

        public int Defense
        {
            get { return mDefense; }
            set { mDefense = value; }
        }

        //get set defense
        int IEquippable.Defense
        {
            get { return mDefense; }
            set { mDefense = value; }
        }

        int IEquippable.Attack
        {
            get; set;
        }

        //method inherited from IEquippable
        public abstract void Equip(Character _character);
    }
}
