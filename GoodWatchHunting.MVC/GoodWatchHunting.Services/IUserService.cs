using System.Collections.Generic;

using HealthKitData.Collections;

namespace GoodWatchHunting.Services
{
  public interface IUserService
  {
    IEnumerable<User> GetAllUsers();

    User GetUser(string id);
  }
}