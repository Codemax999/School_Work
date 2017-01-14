using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE01
{
    class ClassB
    {

        //3 member variables
        string mItem1;
        bool mItem2;
        int mItem3;

        //2 class member variables
        ClassA mClass1;
        ClassC mClass2;

        //default constructor
        public ClassB()
        {
            //print out class name
            Console.WriteLine("ClassB default constructor");
        }

        //parameter constructor 
        public ClassB(string _item1, bool _item2, int _item3)
        {
            //assign parameters to member variables
            mItem1 = _item1;
            mItem2 = _item2;
            mItem3 = _item3;

            //print out class name
            Console.WriteLine("ClassB 3 parameter constructor");
        }

        //parameter class constructor 1
        public ClassB(ClassA _class1)
        {
            //assign parameters to member variables
            mClass1 = _class1;

            //print out class name with parameter
            Console.WriteLine("ClassB with parameter: ClassA");
        }

        //parameter class constructor 2
        public ClassB(ClassC _class2)
        {
            //assign parameters to member variables
            mClass2 = _class2;

            //print out class name with parameter
            Console.WriteLine("ClassB with parameter: ClassC");
        }

        //additional method 1
        public void makeClass(ClassA _class1)
        {
            //instantiate the other class
            mClass2 = new ClassC(_class1);

            //print out class name and parameter
            Console.WriteLine("ClassB method with parameter: ClassA");
        }

        //additional method 2
        public void makeClass2(ClassC _class2)
        {
            //instantiate the other class
            mClass1 = new ClassA(_class2);

            //print out class name and parameter
            Console.WriteLine("ClassB method with parameter: ClassC");
        }

        //final method
        public void finalMethod(ClassA _class1, ClassC _class2)
        {
            //call method 1 and 2
            makeClass(_class1);
            makeClass2(_class2);

            //print out to console
            Console.WriteLine("ClassB calling both methods");
        }
    }
}
