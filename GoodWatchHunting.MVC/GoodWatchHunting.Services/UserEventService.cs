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
  public class UserEventService : IUserEventService
  {
    public IEnumerable<UserEvent> GetAllEventsForUser(string userId)
    {
      var url = string.Format("{0}/users/{1}/events/collection", Configuration.HealthApiBaseUrl, userId);
      var response = WebService.Get(url);
      return !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<IEnumerable<UserEvent>>(response) : new List<UserEvent>();
    }

    public UserEvent GetEventForUser(string userId, string eventId)
    {
      var url = string.Format("{0}/users/{1}/events/{2}", Configuration.HealthApiBaseUrl, userId, eventId);
      var response = WebService.Get(url);
      return !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<UserEvent>(response) : null;
    }
  }
}
