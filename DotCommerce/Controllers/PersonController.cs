using DotCommerce.Models;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace DotCommerce.Controllers
{
    public class PersonController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();

        /// <summary>
        /// Returns welcome message when users log in
        /// </summary>
        /// <returns></returns>
        // GET: People
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Message = "Welcome!";
                return View();
            }
            return RedirectToAction("Register");
        }

        /// <summary>
        /// Display details of a user
        /// </summary>
        /// <param name="id">Person Id</param>
        /// <returns></returns>
        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                     return View("~/Views/Shared/BadRequest.cshtml");
                }
                Person person = db.Person.Find(id);
                if (person == null)
                {
                    return View("~/Views/Shared/BadRequest.cshtml");
                }

                return View(person);
            }
            return View("~/Views/Shared/Forbidden.cshtml");

        }

        /// <summary>
        /// Returns view to register new user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Creates new user in database
        /// </summary>
        /// <param name="person">object of Class Person</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "FirstName,LastName,Email,Password,CPassword")] Person person)
        {
            if (ModelState.IsValid)
            {

                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }

            return View(person);
        }

        /// <summary>
        /// Returns login page for user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Email"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Validates a user to log in 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Person person)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                var p = db.Person.Where(a => a.Email.Equals(person.Email) && a.Password.Equals(person.Password)).FirstOrDefault();
                if (p != null)
                {
                    Session["Email"] = p.Email.ToString();
                    Session["Password"] = p.Password.ToString();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(person);
        }
        /// <summary>
        /// Ends Session of a user
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect("/Home/Index");
        }

        /// <summary>
        /// Validates if email already exists in databse
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult IsExist(string email)
        {
            bool _isExist = false;
            if (db.Person.Where(u => u.Email.ToLower().Equals(email.ToLower())).SingleOrDefault() != null)
            {
                _isExist = true;
            }
            return Json(!_isExist, JsonRequestBehavior.AllowGet);
        }
    }
}
