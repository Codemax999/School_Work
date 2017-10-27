using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CEExceptions
{
    [DataContract]
    class APIdata
    {
        [DataMember]
        List<Person> objects;

        public APIdata()
        {
            objects = new List<Person>();
        }

        public List<Person> People
        {
            get { return objects; }
        }
    }
}
