using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    class StatusMedicine : Item
    {
        public StatusMedicine(int setIntEffect, string setStrEffect, string setDescription) : base(setIntEffect, setStrEffect, setDescription)
        {

        }

        //If the strEffect matches the target's statusEffect then they are cured, if the strEffect is "all" then it is cured
        public override void Use(Character character)
        {
            if(strEffect.ToLower().Equals("all") || strEffect.ToLower().Equals(character.StatusEffect.ToLower()))
            {
                character.StatusEffect = "";
                Console.WriteLine(character.Name + " was cured of " + strEffect + ".");
            }
            else
            {
                Console.WriteLine(character.Name + "'s status was not affected by the status medicine.");
            }
        }
    }
}
