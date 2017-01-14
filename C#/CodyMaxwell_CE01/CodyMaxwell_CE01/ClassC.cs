using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE01
{
    class ClassC
    {

        //3 member variables
        int mItem1;
        double mItem2;
        bool mItem3;

        //2 class member variables
        ClassA mClass1;
        ClassB mClass2;

        //default constructor
        public ClassC()
        {
            //print out class name
            Console.WriteLine("ClassC default constructor");
        }

        //parameter constructor 
        public ClassC(int _item1, double _item2, bool _item3)
        {
            //assign parameters to member variables
            mItem1 = _item1;
            mItem2 = _item2;
            mItem3 = _item3;

            //print out class name
            Console.WriteLine("ClassC 3 parameter constructor");
        }

        //parameter class constructor 1
        public ClassC(ClassA _class1)
        {
            //assign parameters to member variables
            mClass1 = _class1;

            //print out class name with parameter
            Console.WriteLine("ClassC with parameter: ClassA");
        }

        //parameter class constructor 2
        public ClassC(ClassB _class2)
        {
            //assign parameters to member variables
            mClass2 = _class2;

            //print out class name with parameter
            Console.WriteLine("ClassC with parameter: ClassB");
        }

        //additional method 1
        public void makeClass(ClassA _class1)
        {
            //instantiate the other class
            mClass2 = new ClassB(_class1);

            //print out class name and parameter
            Console.WriteLine("ClassC method with parameter: ClassA");
        }

        //additional method 2
        public void makeClass2(ClassB _class2)
        {
            //instantiate the other class
            mClass1 = new ClassA(_class2);

            //print out class name and parameter
            Console.WriteLine("ClassC method with parameter: ClassB");
        }

        //final method
        public void finalMethod(ClassA _class1, ClassB _class2)
        {
            //call method 1 and 2
            makeClass(_class1);
            makeClass2(_class2);

            //print out to console
            Console.WriteLine("ClassC calling both methods");
        }
    }
}
