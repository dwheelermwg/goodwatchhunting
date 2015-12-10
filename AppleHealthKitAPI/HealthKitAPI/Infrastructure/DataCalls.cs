using System.Web.Configuration;
using System.Web.Mvc;

using HealthKitData.Collections;

using MongoDB.Driver;

namespace HealthKitAPI.Infrastructure
{
  public class DataCalls
  {
    private static IMongoClient _client;
    private static IMongoDatabase _database;

    public DataCalls()
    {
      _client = new MongoClient(WebConfigurationManager.AppSettings["MongoDB"]);
      _database = _client.GetDatabase("GoodWatchHunting");
    }

    public JsonResult SaveChainDashboard(User model)
    {
      var collection = _database.GetCollection<User>("User");
      collection.InsertOneAsync((model));

      return new JsonResult();
    }

  }
}