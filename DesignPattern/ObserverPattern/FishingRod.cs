using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class FishingRod:FishingTool
    {
        public void Fishing()
        {
            Console.WriteLine("开始下钩");

            if (new Random().Next() % 2 == 0)
            {
                var type = (FishType)new Random().Next(0, 5);
                Console.WriteLine("铃铛：叮叮叮，鱼儿咬钩了");
                Notify(type);
            }
        }
    }
}
