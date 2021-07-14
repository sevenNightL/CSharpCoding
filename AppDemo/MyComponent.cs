using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    public class MyComponent
    {
        private ILogger _logger;
        private IConfigReader _reader;

        public MyComponent()
        {

        }
        public MyComponent(ILogger logger)
        {
            _logger = logger;
        }
        public MyComponent(ILogger logger,IConfigReader reader)
        {
            _logger = logger;
            _reader = reader;
        }
    }
}
