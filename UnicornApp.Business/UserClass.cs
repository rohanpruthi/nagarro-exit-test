using System.Collections.Generic;
using System.Linq;
using UnicornApp.DAL;

namespace UnicornApp.Business
{
  public class UserClass
  {
    private static UnicornDBEntities db = new UnicornDBEntities();
    /// <summary>
    /// Checks if a user exists in database.
    /// </summary>
    /// <param name="user">variable of class User</param>
    /// <returns></returns>
    public static bool IfUserExist(User user)
    {
      bool result = true;
      if (db.User.Where(u => u.Email.Equals(user.Email.ToLower())) != null)
      {
        result = false;
      }
      return result;
    }

    /// <summary>
    /// Checks email and password of user from database.
    /// </summary>
    /// <param name="email">Email address</param>
    /// <param name="password">Password</param>
    /// <returns></returns>
    public static bool ValidateUserLogin(string email, string password)
    {
      bool result = false;
      var temp = db.User.Where(u => u.Email.Equals(email)).FirstOrDefault();
      if (temp != null && temp.Password == password)
      {
        result = true;
      }
      return result;
    }

    /// <summary>
    /// Checks if two fields of passwords are same.
    /// </summary>
    /// <param name="pass">Password field 1</param>
    /// <param name="confirmPass">Password field 2</param>
    /// <returns></returns>
    public static bool ConfirmUserPassword(string pass, string confirmPass)
    {
      bool result = false;
      if (pass.CompareTo(confirmPass) == 0)
      {
        result = true;
      }
      return result;
    }

    /// <summary>
    /// Find a user (type of class User) from database with parameter email.
    /// </summary>
    /// <param name="email">Email address</param>
    /// <returns></returns>
    public static User FindUserByEmail(string email)
    {
      User user = null;
      user = db.User.Where(u => u.Email.Equals(email.ToLower())).First();
      return user;
    }

    public static int GetFollowing(string email)
    {
      User user = FindUserByEmail(email);
      var list = from f in db.FollowingUser where f.UserId.Equals(user.Id) select f.User1 ;
      return list.Count();
    }
  }
}
