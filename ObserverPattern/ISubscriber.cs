using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    /// <summary>
    /// subscriber 
    /// there are specific subscribers that implement 'Update' method 
    /// </summary>
    public interface ISubscriber
    {
        void Update(FishType type);
    }
}
