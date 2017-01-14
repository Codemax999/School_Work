using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    abstract class Item : IUsable
    {
        protected int intEffect;
        protected string strEffect;
        protected string description;

        public Item(int setIntEffect, string setStrEffect, string setDescription) { 
            intEffect = setIntEffect;
            strEffect = setStrEffect;
            description = setDescription;
        }

        //no generic use functionality for generic items
        public virtual void Use(Character character)
        {

        }
    }
}
