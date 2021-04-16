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
                .DefaultIndex("people");
            var client = new ElasticClient(settings);


            var person = new Person
            {
                Id = 1,
                FirstName = "Marting",
                LastName = "Laarman"
            };
            var indexResponse = client.IndexDocument(person);
           // var asyncIndexResponse = await client.IndexDocumentAsync(person);
            Console.WriteLine("Hello World!");
        }
    }
}
