using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    public interface IDateWriter
    {
        void WriteDate();
    }


    public class TodayWriter : IDateWriter
    {
        private readonly IOutput _output;

        public TodayWriter(IOutput output)
        {
            _output = output;
        }
        public void WriteDate()
        {
            _output.Write(DateTime.Now.ToLongDateString());
        }
    }
}
