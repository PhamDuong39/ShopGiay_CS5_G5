namespace ProjectViews.Services
{
  public interface ISessionService<T> where T : class
  {
    //check exsit T
    public bool CheckObject<En>(List<En> Entity, string key) where En : class;
    //check exsit key
    public void SetObjectAsJson(ISession session, string key, object value);
    public List<T> GetObjectFromSession<Ti>(ISession session, string key) where Ti : class;
  }
}
