using System;
using System.Collections.Generic;
using System.Text;

namespace StaticStruct
{
    class SimpleClass
    {
        public static int StaticCount;

        public static int Number;
        public int NonStaticCount { get; set; }

        static SimpleClass()
        {
            Console.WriteLine("First instance created");
        }

        public SimpleClass()
        {
            StaticCount++;
            NonStaticCount++;
        }

        public  int Sum(int n1,int n2)
        {
            return n1 + n2;
        }
    }
}
