using System;

namespace StaticStruct
{
    class Program
    {
        enum Weekday { Monday=1,Tuesday,Wednesday=254,Thursday};
        static void Main(string[] args)
        {
            #region Sealed
            #endregion

            #region Static
            //SimpleClass simple1 = new SimpleClass();
            //SimpleClass.Number = 10;
            //Console.WriteLine(SimpleClass.Number);
            //SimpleClass simple2 = new SimpleClass();
            //SimpleClass simple3 = new SimpleClass();
            //Console.WriteLine($"simple1: static-{SimpleClass.StaticCount}; non-static-{simple1.NonStaticCount}");
            //Console.WriteLine($"simple2: static-{SimpleClass.StaticCount}; non-static-{simple2.NonStaticCount}");
            //Console.WriteLine($"simple3: static-{SimpleClass.StaticCount}; non-static-{simple3.NonStaticCount}");
            //SimpleClass.Sum(10, 20);
            //SimpleClass.Number = 10;
            //Console.WriteLine(SimpleClass.Number);
            #endregion

            #region Extension
            //string str = "asfad4fad";
            //Console.WriteLine(str.Match(@"[A-Z]"));
            //int input = 10;
            //Console.WriteLine(input.Power(3));
            #endregion

            #region Nullable
            //int? number = null;
            //bool? isSomething = null;
            #endregion

            #region Enum
            int day = 0;
            switch (day)
            {
                case (int)Weekday.Monday:
                    Console.WriteLine("Moday");
                    break;
                case (int)Weekday.Tuesday:
                    Console.WriteLine("Tuesday");
                    break;
                default:
                    Console.WriteLine("Other day");
                    break;
            }
            #endregion
        }
    }


    #region Sealed
    //abstract class Person
    //{
    //    public virtual void Run()
    //    {

    //    }
    //}
    //class Developer:Person
    //{
    //    public sealed override void Run()
    //    {
    //        Console.WriteLine("Developer never run");
    //    }
    //}

    //sealed class FrontEndDeveloper : Developer
    //{
        
    //}

    #endregion
}
