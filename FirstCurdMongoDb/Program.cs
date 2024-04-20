using MongoDB.Bson;
using MongoDB.Driver;

MongoClient _dbClient = new MongoClient("mongodb://localhost:27017");
var database = _dbClient.GetDatabase("mongodbVSCodePlaygroundDB");
var collection = database.GetCollection<BsonDocument>("studentDb");

var document = new BsonDocument
            {
                { "student_id", 10001 },
                { "scores", new BsonArray
                    {
                    new BsonDocument{ {"type", "exam"}, {"score", 89.12334193287023 } },
                    new BsonDocument{ {"type", "quiz"}, {"score", 75.92381029342834 } },
                    new BsonDocument{ {"type", "homework"}, {"score", 88.97929384290324 } },
                    new BsonDocument{ {"type", "homework"}, {"score", 83.12931030513218 } }
                    }
                },
                { "class_id", 480}
            };

collection.InsertOne(document);
await collection.Find(new BsonDocument()).ForEachAsync(document => Console.WriteLine(document));
