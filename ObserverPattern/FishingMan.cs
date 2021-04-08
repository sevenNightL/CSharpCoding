using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    /// <summary>
    /// fishman implement interface of subcriber
    /// </summary>
    public class FishingMan : ISubscriber
    {
        public string Name { get; set; }

        public int FishCount { get; set; }

        public FishingMan(string name)
        {
            Name = name;
        }
        public void Update(FishType type)
        {
            FishCount++;
            Console.WriteLine("{0}:钓到一条【{1}】，已经钓到{2}条鱼了！", Name, type, FishCount);
        }
    }
}
