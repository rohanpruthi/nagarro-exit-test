using DotCommerce.Models;
using DotCommerce.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotCommerce.Controllers
{
    public class ProductController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();

        // GET: Product
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Category);
            return View(product.ToList());
        }

        /// <summary>
        /// Returns Details of a Product and available variant
        /// Product can be added to cart from here only to logged in users
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        // GET: Product/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (Session["Email"] != null)
            {

                if (id == null)
                {
                    return View("~/Views/Shared/BadRequest.cshtml");
                }
                var product = db.Product.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                ProductViewModel pv = new ProductViewModel();
                pv.Id = product.Id;
                pv.Title = product.Title;
                pv.Description = product.Description;
                pv.CategoryTitle = product.Category.Title;
                pv.Price = product.Price;
                //pv.ImageUrl = product.Image;

                pv.Variants = new List<SelectListItem>();
                foreach (var item in product.ProductVariant)
                {
                    pv.Variants.Add(new SelectListItem() { Text = item.VariantTitle, Value = item.VariantTitle });
                }


                return View("ProductDetails", pv);
            }
            return View("~/Views/Shared/Forbidden.cshtml");
        }

        /// <summary>
        /// Redirects to 'add to card' action
        /// </summary>
        /// <param name="pv">Object of ProductViewModel</param>
        [HttpPost]
        public void Details(ProductViewModel pv)
        {
            RedirectToAction("Create", "Cart", pv);
        }

    }
}
