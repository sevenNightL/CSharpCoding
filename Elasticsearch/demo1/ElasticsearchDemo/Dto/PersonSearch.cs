using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchDemo.Dto
{
    public class PersonSearch
    {
        public string first_name { get; set; }
        public string last_name { get; set; }

        public int age { get; set; }

        public string about { get; set; }
        public string[] interests { get; set; }

    }
}
