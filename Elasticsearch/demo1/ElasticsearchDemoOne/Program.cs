using Nest;
using System;

namespace ElasticsearchDemoOne
{
    class Program
    {
        static  void Main(string[] args)
        {
            //var client = new ElasticClient();
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("megacorp");
            var client = new ElasticClient(settings);

            var result = client.Search<Person>();
            var result1 = client.Search<Person>(x => x.Query(x1 => x1.Bool(x2 => x2.MustNot(x3 => x3.Match(x4=>x4.Field(f=>f.interests).Query("music"))))));
           // var asyncIndexResponse = await client.IndexDocumentAsync(person);
            Console.WriteLine("Hello World!");
        }
    }
}
