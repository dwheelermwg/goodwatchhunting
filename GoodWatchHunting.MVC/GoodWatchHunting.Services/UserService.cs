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
  public class UserService
  {
    public IEnumerable<User> GetAllUsers()
    {
      var url = string.Format("{0}/users/collection", Configuration.HealthApiBaseUrl);
      var response = WebService.Get(url);
      return !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<IEnumerable<User>>(response) : new List<User>();
    }

    public User GetUser(string id)
    {
      var url = string.Format("{0}/users/{1}", Configuration.HealthApiBaseUrl, id);
      var response = WebService.Get(url);
      return !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<User>(response) : null;
    }
  }
}
