using System;
using System.Threading;

namespace TryCatchDemo
{
    class Program
    {
        private static  readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test();
         
        }


        static void Test()
        {
            _lock.EnterReadLock();
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
                _lock.ExitReadLock();
                Console.ReadLine();
            }

            _lock.EnterWriteLock();

            try
            {
                Console.WriteLine("try2 executed");
            }
            finally 
            {

                Console.WriteLine("finally2 executed");
                _lock.ExitWriteLock();
                Console.ReadLine();;
            }
        }
    }
}
