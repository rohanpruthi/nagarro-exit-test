using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using UnicornApp.Business;
using UnicornApp.DAL;

namespace UnicornApp.Controllers
{
  public class DummyController : Controller
  {
    private UnicornDBEntities db = new UnicornDBEntities();
    // GET: Users
    public string Index()
    {
      return "Hello, World!";
    }

    // GET: Users/Details/5
    public List<string> GetUsers()
    {
      var user = db.User.Select(u => u.Email).ToList();
      return user;
    }

    //// GET: Users/Create
    //public ActionResult Create()
    //{
    //  return View();
    //}

    // POST: Users/SignUp
    [HttpPost]
    public JsonResult SignUp([Bind(Include = "Email,Password,FirstName,LastName,Contact,Region,Image")] User user)
    {
      if (ModelState.IsValid)
      {
        db.User.Add(user);
        db.SaveChanges();
      }
      string json = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
      {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
      });
      return Json(json, JsonRequestBehavior.AllowGet);
    }
    [HttpPost]
    public JsonResult Login(string email, string password)
    {
      if (UserClass.ValidateUserLogin(email, password))
      {
        var user = UserClass.FindUserByEmail(email);
        Session["Email"] = email;
        Session["Password"] = password;
        Session["UserId"] = UserClass.FindUserByEmail(email).Id;
        //User user = UserClass.FindUserByEmail(email);
        string json = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
        {
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        return Json(json, JsonRequestBehavior.AllowGet); //Session["Email"].ToString() + Session["UserId"];
      }
      return Json(new { status = false});
    }

    [HttpPost]
    public ActionResult Logout()
    {
      FormsAuthentication.SignOut();
      Session.Abandon();
      return new HttpStatusCodeResult(200);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
    [HttpGet]
    public JsonResult IsExist(string email)
    {
      bool _isExist = false;
      if (db.User.Where(u => u.Email.ToLower().Equals(email.ToLower())).SingleOrDefault() != null)
      {
        _isExist = true;
      }
      return Json(!_isExist, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public bool FollowUser(int? id)
    {
      bool result = false;
      int userId = Convert.ToInt32(Session["UserId"]);
      if (ModelState.IsValid && Session["UserId"] != null && id!= userId && id!=null)
      { //int userId = Convert.ToInt32(Session["UserId"]);
        var temp = db.FollowingUser.Where(f => f.UserId == userId && f.FollowingUserId == id).FirstOrDefault();
        if (temp == null)
        {
          FollowingUser user = new FollowingUser();
          user.UserId = userId;
          user.FollowingUserId = Convert.ToInt32(id);
          db.FollowingUser.Add(user);
          db.SaveChanges();
          result = true;
        }
      }
      return result;
    }

    [HttpGet]
    public List<User> GetFollowing()
    {
      if (ModelState.IsValid && Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"]);
        var user = db.FollowingUser.Where(u => u.UserId == userId).Select(u => u.User1);
        return user.ToList();
      }
      return null;
    }

    [HttpPost]
    public bool Unfollow(int id)
    {
      var result = false;
      if (ModelState.IsValid && Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"]);
        var delUser = db.FollowingUser.Where(u => u.UserId == userId && u.FollowingUserId == id).FirstOrDefault();
        if (delUser != null)
        {
          db.FollowingUser.Remove(delUser);
          db.SaveChanges();
          result = true;
        }
      }
      return result;
    }

  }
}
