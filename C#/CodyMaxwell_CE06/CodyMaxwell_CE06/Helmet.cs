using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    class Helmet : Armor
    {
        public Helmet(int _defense) : base(_defense)
        {

        }

        //Equip method should place helmet into the equipped armor Dictionary of the Character parameter
        //store with a key of helmet
        public override void Equip(Character _character)
        {
            _character.Armors.Add("helmet", this);
        }
    }
}
