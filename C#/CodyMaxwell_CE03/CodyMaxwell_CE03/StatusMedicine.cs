using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE03
{
    class StatusMedicine : Item
    {
        //Use method
        //will make Character parameter's statusEffect string an empty string if: 
        //1) The StatusMedicine's string effect value matches the Character parameter's statusEffect string
        //2) The StatusMedicine's string effect value is "all" 
        public override void Use(Character _character)
        {
            Console.WriteLine("{0} - {1}", strEffect.ToLower().Trim(), _character.StatusEffect.ToLower().Trim()); 
            if (strEffect.ToLower().Trim() == _character.StatusEffect.ToLower().Trim() || strEffect.ToLower().Trim() == "all")
            {
                _character.StatusEffect = "";
            }
        }
    }
}
