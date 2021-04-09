using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InsertMongo
{
    class Connect
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://xiaobai:a!xf716924@localhost:27017");

            var database = client.GetDatabase("admin");
            database.CreateCollection("testCollection");
           var collection = database.GetCollection<BsonDocument>("testCollection");

            var document = new BsonDocument
            {
                { "item","canvas"},
                { "qty",100},
                { "tags",new BsonArray{ "cotton","HM" } },
                { "size",new BsonDocument{ { "h",28 },{ "w",35.5 },{ "uom","cm"} } }
            };

            collection.InsertOne(document);

            Console.WriteLine("Hello World!");
        }
    }
}
