using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AwaitAsyncDemo1
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggTask = FryEggsAsync(2);
            Egg eggs =await eggTask;
            Console.WriteLine("eggs are ready");

            Task<Bacon> baconTask = FryBaconAsync(3);
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Task<Toast> toastTask = ToastBreadAsync(2);
            Toast toast = await toastTask;
           
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("breakfast is ready");
        }



        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private  static Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return Task.FromResult( new Toast());
        }

        private  static Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting{slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");
            return Task.FromResult( new Bacon());
        }

        private  static Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            return Task.FromResult( new Egg());
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}
