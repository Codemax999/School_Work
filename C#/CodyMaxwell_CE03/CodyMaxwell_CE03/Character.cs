using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE03
{
    public class Character
    {
        //member variables
        string mName;
        int mHealth;
        string mStatusEffect;

        //only name constructor
        public Character()
        {
            //nothing
        }

        //constructor
        public Character(string _name, int _health, string _statusEffect)
        {
            //assign to member variables
            mName = _name;
            mHealth = _health;
            mStatusEffect = _statusEffect;
        }

        //mName getter setter
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        //mHealth getter setter
        public int Health
        {
            get { return mHealth; }
            set { mHealth = value; }
        }

        //mStatusEffect getter setter
        public string StatusEffect
        {
            get { return mStatusEffect; }
            set { mStatusEffect = value; }
        }

    }
}
