using MongoDB.Bson;
using MongoDB.Driver;

namespace ControlWorkBlazor.Data
{
    public class MongoConnection
    {
        public static User? currUser;
        public static void AddToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Users");
            var collection = database.GetCollection<User>("UserCollection");
            collection.InsertOne(user);
        }

        public static void ReplaceOneInDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Users");
            var filter = new BsonDocument("_id", user._id);
            var collection = database.GetCollection<User>("UserCollection");
            collection.ReplaceOne(filter, user);
        }
        public static IMongoCollection<User> GetUsersCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Users");
            return database.GetCollection<User>("UsersCollection");
        }

        public static User FindByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var filter = Builders<User>.Filter.Eq("Login", login);
            var database = client.GetDatabase("Users");
            var collection = database.GetCollection<User>("UsersCollection");
            return collection.Find(filter).FirstOrDefault();
        }

    }
}
