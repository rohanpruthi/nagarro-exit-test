using DotCommerce.Models;
using DotCommerce.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DotCommerce.Controllers
{
    public class CartController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();

        // GET: Cart
        /// <summary>
        /// To view all the products added in the card in a list
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return View("~/Views/Shared/Forbidden.cshtml");
            }
            var cart = db.Cart.Include(c => c.Person).Include(c => c.ProductVariant);
            return View(cart.ToList());
        }


        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add a product from cart to Product Details
        /// </summary>
        /// <param name="pv"></param>
        /// <param name="Variants">Variant Title of product be added in the cart</param>
        /// <param name="Id">Id of Person related to the cart</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ProductViewModel pv, string Variants, int Id)
        {
            string email = Convert.ToString(Session["Email"]);
            int customerId = (from c in db.Person
                              where c.Email.Contains(email)
                              select c.Id).First();
            int pvid = (from foo in db.ProductVariant
                        where (foo.VariantTitle.Equals(Variants)) &&
                             (foo.ProductId.Equals(Id))
                        select foo.Id).First();

            Cart cart = new Cart();
            cart.ProductVariantId = pvid;
            cart.PersonId = customerId;


            db.Cart.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
