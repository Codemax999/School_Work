using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CEExceptions
{
    [DataContract]
    class Person
    {
        [DataMember]
        string firstname;

        [DataMember]
        string middlename;

        [DataMember]
        string lastname;

        [DataMember]
        string birthday;

        int age;

        Dictionary<String, Object> traits;

        public Person()
        {
            firstname = "N/A";
            middlename = "N/A";
            lastname = "N/A";
            birthday = "N/A";
            age = -1;
            traits = new Dictionary<String, Object>();
        }
        
        public string FirstName
        {
            get{ return firstname; }
            set{ firstname = value; }
        }
        
        public string MiddleName
        {
            get{ return middlename; }
            set{ middlename = value; }
        }

        public string LastName
        {
            get{ return lastname; }
            set{ lastname = value; }
        }

        public int Age
        {
            get
            {
                if(age < 1 && !Birthday.Equals(""))
                {
                    DateTime date = DateTime.Parse(birthday);
                    age = DateTime.Now.Year - date.Year;
                }
                return age;
            }
            set{ age = value;  }
        }

        public Dictionary<string, object> Traits
        {
            get{ return traits; }
        }
        
        public string Birthday
        {
            get{ return birthday; }
            set
            {
                birthday = value;
                DateTime date = DateTime.Parse(birthday);
                Age = DateTime.Now.Year - date.Year;
            }
        }

        public void AddTrait(String traitName, Object traitValue)
        {
            Traits.Add(traitName, traitValue);
        }

        public override string ToString()
        {
            String retVal = String.Format("Name: {0} {1} {2}\nAge: {3}\nBirthday: {4}\n", FirstName, MiddleName, LastName, Age, Birthday);

            if (Traits != null)
            {
                foreach (string key in Traits.Keys)
                {
                    retVal += key + ": " + Traits[key] + " \n";
                }
            }

            return retVal;
        }
    }
}
