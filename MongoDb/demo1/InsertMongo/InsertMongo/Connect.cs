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


            Console.WriteLine("Hello World!");
        }

        public static void InsertDb(MongoDatabaseBase db)
        {
            //database.CreateCollection("testCollection");
            var collection = db.GetCollection<BsonDocument>("testCollection");
            var documents = new[]
            {
                new BsonDocument
                {
                    { "item", "journal" },
                    { "qty", 25 },
                    { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
                    { "status", "A" }
                },
                new BsonDocument
                {
                    { "item", "notebook" },
                    { "qty", 50 },
                    { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
                    { "status", "A" }
                },
                new BsonDocument
                {
                    { "item", "paper" },
                    { "qty", 100 },
                    { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
                    { "status", "D" }
                },
                new BsonDocument
                {
                    { "item", "planner" },
                    { "qty", 75 },
                    { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
                    { "status", "D" }
                },
                new BsonDocument
                {
                    { "item", "postcard" },
                    { "qty", 45 },
                    { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
                    { "status", "A" } },
            };
            collection.InsertMany(documents);

        }

        public static void SelectDb(MongoDatabaseBase db)
        {
            var collection = db.GetCollection<BsonDocument>("testCollection");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            foreach (var doc in result)
            {
                Console.WriteLine(doc.ToJson());
            }
        }

        public static void SeletctDbWithQueries(MongoDatabaseBase db)
        {
            var collection = db.GetCollection<BsonDocument>("testCollection");
            var filter = Builders<BsonDocument>.Filter.Eq("status", "D");
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc.ToJson());
            }

            var filter2 = Builders<BsonDocument>.Filter.Eq("size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } });
            var result2 = collection.Find(filter2).ToList();
            foreach (var doc in result2)
            {
                Console.WriteLine(doc.ToJson());
            }

            var filter3 = Builders<BsonDocument>.Filter.Eq("size.uom", "in");
            var result3 = collection.Find(filter).ToList();
            foreach (var doc in result3)
            {
                Console.WriteLine(doc.ToJson());
            }

        }

    }
}
