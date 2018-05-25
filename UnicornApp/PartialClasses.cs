using System.ComponentModel.DataAnnotations;

namespace UnicornApp
{
  public class PartialClasses
  {
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }
    [MetadataType(typeof(TweetMetadata))]
    public partial class Tweet
    {    
    }
  }
}
