using UnicornApp.DAL;

namespace UnicornApp.Business
{
  public class TweetClass
  {
    private UnicornDBEntities db = new UnicornDBEntities();

    /// <summary>
    /// Validate length of tweet, between 1 to 240 characters (both inclusive).
    /// </summary>
    /// <param name="tweetBody">Tweet body</param>
    /// <returns>Boolean value</returns>
    public static bool ValidateTweet(string tweetBody)
    {
      bool result = false;
      if(tweetBody.Length > 0 && tweetBody.Length <= 240)
      {
        result = true;
      }
      return result;
    }
  }
}
