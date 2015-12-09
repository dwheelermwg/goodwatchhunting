using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

using HealthKitData.Collections;

using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthKitAPI.Controllers
{
  public class HealthKitController : Controller
  {
    private static IMongoClient client;
    private static IMongoDatabase database;


    [System.Web.Http.HttpGet]
    public async Task<JsonResult> AllEvents()
    {
      client = new MongoClient(WebConfigurationManager.AppSettings["MongoDB"]);
      database = client.GetDatabase("GoodWatchHunting");

      var allEvents = new List<Event>();
      var eventCollection = database.GetCollection<BsonDocument>("Event");
      var filter = new BsonDocument();

      using (var cursor = await eventCollection.FindAsync(filter))
      {
        while (await cursor.MoveNextAsync())
        {
          var batch = cursor.Current;
          foreach (var document in batch)
          {
            var tempEvent = new Event();
            tempEvent.EventId = Convert.ToInt32(document["EventId"].AsString);
            tempEvent.EventName = document["EventName"].AsString;
            tempEvent.Message = document["Message"].AsString;
            tempEvent.EventType = (EventType)Convert.ToInt32(document["EventType"].AsString);
            tempEvent.Goal = document["Goal"].AsString;

            allEvents.Add(tempEvent);
          }
        }
      }

      return Json(allEvents, JsonRequestBehavior.AllowGet);
    }

    [System.Web.Http.HttpGet]
    public async Task<JsonResult> GetEventById(int id)
    {
      client = new MongoClient(WebConfigurationManager.AppSettings["MongoDB"]);
      database = client.GetDatabase("GoodWatchHunting");
      var tempEvent = new Event();

      var eventCollection = database.GetCollection<BsonDocument>("Event");
      var filter = Builders<BsonDocument>.Filter.Eq("EventId", id.ToString(CultureInfo.InvariantCulture));

      using (var cursor = await eventCollection.FindAsync(filter))
      {
        while (await cursor.MoveNextAsync())
        {
          var batch = cursor.Current;
          foreach (var document in batch)
          {           
            tempEvent.EventId = Convert.ToInt32(document["EventId"].AsString);
            tempEvent.EventName = document["EventName"].AsString;
            tempEvent.Message = document["Message"].AsString;
            tempEvent.EventType = (EventType)Convert.ToInt32(document["EventType"].AsString);
            tempEvent.Goal = document["Goal"].AsString;
          }
        }
      }

      return Json(tempEvent, JsonRequestBehavior.AllowGet);
    }

    [System.Web.Http.HttpGet]
    public async Task<JsonResult> GetEventByUserId(string userId)
    {
      client = new MongoClient(WebConfigurationManager.AppSettings["MongoDB"]);
      database = client.GetDatabase("GoodWatchHunting");
      var tempEvent = new Event();

      var eventCollection = database.GetCollection<BsonDocument>("Event");
      var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId.ToString(CultureInfo.InvariantCulture));

      using (var cursor = await eventCollection.FindAsync(filter))
      {
        while (await cursor.MoveNextAsync())
        {
          var batch = cursor.Current;
          foreach (var document in batch)
          {
            tempEvent.EventId = Convert.ToInt32(document["EventId"].AsString);
            tempEvent.EventName = document["EventName"].AsString;
            tempEvent.Message = document["Message"].AsString;
            tempEvent.EventType = (EventType)Convert.ToInt32(document["EventType"].AsString);
            tempEvent.Goal = document["Goal"].AsString;
          }
        }
      }

      return Json(tempEvent, JsonRequestBehavior.AllowGet);
    }
  }
}
