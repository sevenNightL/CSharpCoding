using System;

namespace TryCatchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test();
         
        }


        static void Test()
        {
            try
            {
                if (true)
                {
                    Console.WriteLine("try1 executed");
                    return;
                }

            }
            finally
            {

                Console.WriteLine("finally1 executed");
                Console.ReadLine();
            }



            try
            {
                Console.WriteLine("try2 executed");
            }
            finally 
            {

                Console.WriteLine("finally2 executed");
                Console.ReadLine();;
            }
        }
    }
}
