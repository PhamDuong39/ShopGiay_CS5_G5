using Newtonsoft.Json;

namespace ProjectViews.Services
{
  public class SessionServices
  {
    public static List<T> GetObjectFromSession<T>(string key, ISession session)
    {
      //step 1: get value from session
      var value = session.GetString(key);
      if (value == null) // if value == null => return new List<T>()
      {
        return new List<T>();
      }
      return JsonConvert.DeserializeObject<List<T>>(value); // if value different null => return JsonConvert.DeserializeObject<List<T>>(value)
    }
    // step 2: set value to session
    public static void SetObjectToSession<T>(string key, object value, ISession session)
    {
      session.SetString(key, JsonConvert.SerializeObject(value));
    }
  }
}
