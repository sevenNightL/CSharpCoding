using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeDemo
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            var str = Guid.NewGuid().ToString();
            OperationId = str.Substring(str.Length-4,4);         

        }
        public string OperationId  { get; }
    }
}
