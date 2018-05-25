using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UnicornApp.DAL;
using UnicornApp.Business;
using Newtonsoft.Json;

namespace UnicornApp.Controllers
{
  public class TweetsController : Controller
  {
    private UnicornDBEntities db = new UnicornDBEntities();

    // GET: Tweets
    public ActionResult Index()
    {
      if (Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"]);
        var followingId = db.FollowingUser.Where(u => u.UserId == userId).Select(u => u.FollowingUserId).ToList();
        var tweet = db.Tweet.Where(t => t.UserId == userId).Include(t => t.User).Select(u => new { u.Id, u.Body, u.UserId, u.CreatedAt, u.User.Email }).ToList();
        foreach(var item in followingId)
        {
          var temp = db.Tweet.Where(t => t.UserId == item).Include(t => t.User).Select(u => new { u.Id, u.Body, u.UserId, u.CreatedAt, u.User.Email }).FirstOrDefault();
          if (temp != null)
          {
            tweet.Add(temp);
          }
        }
        string json = JsonConvert.SerializeObject(tweet, Formatting.Indented, new JsonSerializerSettings
        {
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        return Json(tweet,JsonRequestBehavior.AllowGet);
      }
      return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
    }


    // POST: Tweets/Create
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public string Create(string tweetBody)
    {
      if (ModelState.IsValid && Session["UserId"] != null && TweetClass.ValidateTweet(tweetBody))
      {
        Tweet tweet = new Tweet();
        tweet.Body = tweetBody;
        tweet.UserId = Convert.ToInt32(Session["UserId"]);
        db.Tweet.Add(tweet);
        db.SaveChanges();
        return tweet.Body + "\n" + tweet.UserId;
      }

      return "error";
    }

    // GET: Tweets/Edit/5
    //public ActionResult Edit(int? id)
    //{
    //  if (id == null)
    //  {
    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //  }
    //  Tweet tweet = db.Tweet.Find(id);
    //  if (tweet == null)
    //  {
    //    return HttpNotFound();
    //  }
    //  ViewBag.UserId = new SelectList(db.User, "Id", "Email", tweet.UserId);
    //  return View(tweet);
    //}

    // POST: Tweets/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult Edit(string tweetBody, int? id)
    {
      ActionResult result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
      if (ModelState.IsValid && Session["UserId"] != null)
      {
        var tweet = db.Tweet.Find(id);
        tweet.Body = tweetBody;
        db.SaveChanges();
        result = RedirectToAction("Index");
      }
      return result;
    }

    // GET: Tweets/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Tweet tweet = db.Tweet.Find(id);
      if (tweet == null)
      {
        return HttpNotFound();
      }
      return View(tweet);
    }

    // POST: Tweets/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Tweet tweet = db.Tweet.Find(id);
      db.Tweet.Remove(tweet);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
    [HttpPost]
    public bool CreateLikeDislikeTweet(int id, bool likeDislike)
    {
      bool result = false;
      if (ModelState.IsValid && Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"]);
        var temp = db.TweetLikeDislike.Where(t => t.UserId == userId && t.TweetId == id).FirstOrDefault();
        if (temp == null)
        {
          TweetLikeDislike tweet = new TweetLikeDislike();
          tweet.UserId = Convert.ToInt32(Session["UserId"]);
          tweet.TweetId = id;
          tweet.LikeDislike = likeDislike;
          db.TweetLikeDislike.Add(tweet);
          db.SaveChanges();
          result = true;
        }
      }
      return result;
    }

    [HttpPost]
    public bool EditLikeDislikeTweet(int id)
    {
      bool result = false;
      if (ModelState.IsValid && Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"]);
        TweetLikeDislike tweet = db.TweetLikeDislike.Find(id);
        if (tweet != null && tweet.UserId == userId)
        {
          tweet.LikeDislike = !tweet.LikeDislike;
          db.SaveChanges();
          result = true;
        }
      }
      return result;
    }

    [HttpPost]
    public bool DeleteLikeDislikeTweet(int id)
    {
      bool result = false;
      if (ModelState.IsValid && Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"]);
        TweetLikeDislike tweet = db.TweetLikeDislike.Find(id);
        if (tweet != null && tweet.UserId == userId)
        {
          db.TweetLikeDislike.Remove(tweet);
          db.SaveChanges();
          result = true;
        }
      }
      return result;
    }


  }
}
