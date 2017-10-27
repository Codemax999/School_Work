using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    class Weapon : IEquippable
    {
        //member variables
        private int mAttack;

        public Weapon()
        {

        }

        //constructor
        public Weapon(int _attack)
        {
            mAttack = _attack;
        }

        public int Attack
        {
            get { return mAttack; }
            set { mAttack = value; }
        }

        //get set attack
        int IEquippable.Attack
        {
            get { return mAttack; }
            set { mAttack = value; }
        }

        int IEquippable.Defense
        {
            get; set;
        }

        //Equip method assigns character weapon
        public void Equip(Character _character)
        {
            _character.CurrentWeapon = this;
        }
    }
}
