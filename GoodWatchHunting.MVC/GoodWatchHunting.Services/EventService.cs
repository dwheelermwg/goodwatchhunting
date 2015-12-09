using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoodWatchHunting.Domain;

using HealthKitData.Collections;

using Newtonsoft.Json;

namespace GoodWatchHunting.Services
{
  public class EventService : IEventService
  {
    public IEnumerable<Event> GetAllEvents()
    {
      var url = string.Format("{0}/events/collection", Configuration.HealthApiBaseUrl);
      var response = WebService.Get(url);
      return !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<IEnumerable<Event>>(response) : new List<Event>();
    }

    public Event GetEvent(string id)
    {
      var url = string.Format("{0}/events/{1}", Configuration.HealthApiBaseUrl, id);
      var response = WebService.Get(url);
      return !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<Event>(response) : null;
    }
  }
}
