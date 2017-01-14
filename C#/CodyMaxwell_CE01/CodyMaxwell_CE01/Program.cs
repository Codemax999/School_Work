using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE01
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Cody Maxwell
             * 11-23-2016
             * MDV2430-O
             * Code Exercise 01: Classes and Methods
             */

            //instantiate 3 classes with constructors
            ClassA initialClass1 = new ClassA("custom string", 182, 30.12);
            ClassB initialClass2 = new ClassB("second custom string", true, 561);
            ClassC initialClass3 = new ClassC(9, 50.50, false);

            //call class A final method
            initialClass1.finalMethod(initialClass2, initialClass3);
            //call class B final method
            initialClass2.finalMethod(initialClass1, initialClass3);
            //call class C final method
            initialClass3.finalMethod(initialClass1, initialClass2);

        }
    }
}
