using System.Collections.Generic;

using HealthKitData.Collections;

namespace GoodWatchHunting.Services
{
  public interface IUserEventService
  {
    IEnumerable<UserEvent> GetAllEventsForUser(string userId);

    UserEvent GetEventForUser(string userId, string eventId);
  }
}