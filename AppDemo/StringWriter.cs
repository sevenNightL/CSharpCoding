using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    public class StringWriter : TextWriter
    {
        public override Encoding Encoding => throw new NotImplementedException();
    }
}
