using System.Collections.Generic;

using HealthKitData.Collections;

namespace GoodWatchHunting.Services
{
  public interface IEventService
  {
    IEnumerable<Event> GetAllEvents();

    Event GetEvent(string id);
  }
}