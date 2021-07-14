using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    public interface IConfigReader
    {
        
    }
    public class ConfigReader:IConfigReader
    {
        private string _mySection;

        public ConfigReader(string mySection)
        {
            _mySection = mySection;
        }
    }
}
