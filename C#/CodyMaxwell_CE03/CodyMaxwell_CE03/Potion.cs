using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE03
{
    class Potion : Item
    {
        //Use method: 
        //add int effect value to Character parameter's health
        //set new value as Character Health
         public override void Use(Character _character)
        {
            _character.Health = _character.Health + intEffect;
        }
    }
}
