using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GoodWatchHunting.Services
{
  public class WebService
  {
    public static string Get(string apiUrl)
    {
      var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
      httpWebRequest.KeepAlive = false;
      httpWebRequest.Accept = "application/json";
      httpWebRequest.Method = "GET";

      using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
      {
        var responseStream = response.GetResponseStream();
        if (responseStream != null && response.StatusCode == HttpStatusCode.OK)
        {
          using (var streamReader = new StreamReader(responseStream))
          {
            return streamReader.ReadToEnd();
          }
        }
      }
      return null;
    }
  }
}
