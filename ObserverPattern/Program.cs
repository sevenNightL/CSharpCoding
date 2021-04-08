using System;
using System.Threading;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! I am fishing fish.");
            SimpleObserverTest();
            Console.ReadLine();
        }

        private static void SimpleObserverTest()
        {
            Console.WriteLine("简单实现的观察者模式：");
            Console.WriteLine("====================");
            //Init rob
            var fishingRod = new FishingRod();
            //Init fishman
            var sifan = new FishingMan("思凡");

            //fishman observe rob
            fishingRod.AddSubcriber(sifan);

            while (sifan.FishCount<5)
            {
                fishingRod.Fishing();
                Console.WriteLine("------------------");
                Thread.Sleep(5000);
            }
        }
    }
}
