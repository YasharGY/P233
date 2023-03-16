using System;
using System.Collections.Generic;
using System.Text;

namespace StaticStruct
{
    static class StaticClass
    {
        static StaticClass()
        {
            MyProperty = 100;
        }
        public static int MyProperty { get; }
    }
}
