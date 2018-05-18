using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotCommerce.Models;

namespace DotCommerce.Controllers
{
    public class CategoryController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();

        // GET: Category
        /// <summary>
        /// Display all categories
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        /// <summary>
        /// Display all products in each category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

    }
}
