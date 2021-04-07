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
        public void Update(FishType type)
        {
            throw new NotImplementedException();
        }
    }
}
