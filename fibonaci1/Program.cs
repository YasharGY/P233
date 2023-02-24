using System;

namespace fibonaci1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            int thirdNumber = 1;
          
            while (thirdNumber<9)
            {
                Console.WriteLine(thirdNumber);
                thirdNumber = firstNumber + secondNumber;
              firstNumber=secondNumber;
                secondNumber = thirdNumber;
                
            }
        }
    }
}
