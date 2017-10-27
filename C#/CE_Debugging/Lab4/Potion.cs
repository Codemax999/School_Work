using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    class Potion : Item
    {
        public Potion(int setIntEffect, string setStrEffect, string setDescription) : base(setIntEffect, setStrEffect, setDescription)
        {

        }

        //restores intEffect to the target's health value
        public override void Use(Character character)
        {
            Console.WriteLine("Used " + description + " on " + character.Name + ".");
            character.Health += intEffect;
            Console.WriteLine(character.Name + " gained " + intEffect + " health from the potion.");
        }
    }
}
