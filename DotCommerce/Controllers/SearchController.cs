using DotCommerce.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DotCommerce.Controllers
{
    public class SearchController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();
        /// <summary>
        /// Searches for a product or product description with a searchbox
        /// Display results or not found message.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        // GET: Search
        public ActionResult Search(string searchString)
        {
            ViewBag.NoSearch = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                var product = db.Product.Where(s => s.Title.Contains(searchString)
                        || s.Description.Contains(searchString));
                if (product.Count() == 0)
                {
                    ViewBag.NoSearch = "No product(s) match the search criteria";
                }
                return View("SearchResult", product);
            }
            return new HttpStatusCodeResult(404);
        }
    }
}