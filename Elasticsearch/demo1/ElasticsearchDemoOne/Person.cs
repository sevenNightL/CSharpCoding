using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticsearchDemoOne
{
    public class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public int age { get; set; }

        public string about { get; set; }
        public string[] interests { get; set; }
    }
}
