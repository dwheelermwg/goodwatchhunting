using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWatchHunting.Domain
{
  public class Configuration
  {
    public static string HealthApiBaseUrl
    {
      get
      {
        return ConfigurationManager.AppSettings["HealthApiBaseUrl"];
      }
    }
  }
}
