using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

using HealthKitData.Collections;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HealthKitAPI.Controllers
{
  public class HealthKitController : Controller
  {
    private static IMongoClient _client;
    private static IMongoDatabase _database;


    [System.Web.Http.HttpGet]
    public async Task<IMongoCollection<BsonDocument>> AllEvents()
    {
      _client = new MongoClient(WebConfigurationManager.AppSettings["MongoDB"]);
      _database = _client.GetDatabase("GoodWatchHunting");

      var allEvents = new Collection<Events>();
      var eventCollection = _database.GetCollection<BsonDocument>("Event");
      var filter = new BsonDocument();

      using (var cursor = await eventCollection.FindAsync(filter))
      {
        while (await cursor.MoveNextAsync())
        {
          var batch = cursor.Current;
          foreach (var document in batch)
          {
            allEvents.Add(BsonSerializer.Deserialize<Events>(document));
          }
        }
      }
      return eventCollection;
    }
  }
}
