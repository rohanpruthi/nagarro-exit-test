using DotCommerce.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotCommerce.Controllers
{
    public class OrderDetailController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();

        // GET: OrderDetails
        /// <summary>
        /// Returns all past orders created by a particular user
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string email = Convert.ToString(Session["Email"]);
            if (string.IsNullOrEmpty(email) == true)
            {
                return View("~/Views/Shared/Forbidden.cshtml");
            }
            int id = (from p in db.Person
                      where p.Email.Contains(email)
                      select p.Id).Single();
            var orderDetail = db.OrderDetail.Include(o => o.Person).Include(o => o.Product);
            orderDetail = orderDetail.Where(o => o.PersonId.Equals(id));
            return View(orderDetail.ToList());
        }

        // GET: OrderDetails/Details/5
        /// <summary>
        /// Returns Details of a placed order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {

            if (Session["Email"] == null)
            {
                return View("~/Views/Shared/Forbidden.cshtml");
            }
            if (id == null)
            {
                return View("~/Views/Shared/BadRequest.cshtml");
            }
            string email = Convert.ToString(Session["Email"]);
            int personId = (from p in db.Person
                            where p.Email.Contains(email)
                            select p.Id).Single();
            //var orderCount = (from o in db.OrderDetail
            //                  join p in db.Person on
            //                  o.PersonId equals p.Id
            //                  where o.PersonId.Equals(personId)
            //                  select o.OrderId).Count();
            var orderCheck = db.OrderDetail.Include(o => o.Person).Include(o => o.Product);
            orderCheck = orderCheck.Where(o => o.PersonId.Equals(personId));

            if (orderCheck.Select(o => o.Id).ToList().Contains(id.GetValueOrDefault()))
            {

                OrderDetail orderDetail = db.OrderDetail.Find(id);
                //if (orderDetail == null)
                //{
                //    return View("~/Views/Shared/NotFound.cshtml");
                //}
                return View(orderDetail);
            }
            return View("~/Views/Shared/BadRequest.cshtml");
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                int top = (from c in db.Cart select c.Id).First();
                int cartCount = db.Cart.Count();
                for (int i = top; i < top + cartCount; i++)
                {
                    var cart = db.Cart.Find(i);
                    int pdId = cart.ProductVariant.Product.Id;
                    int vId = cart.ProductVariantId;
                    OrderDetail order = new OrderDetail();

                    order.ProductId = pdId;

                    order.VariantId = vId;
                    if (!db.OrderDetail.Select(o => o.OrderId).Any())
                    {
                        order.OrderId = 1800;
                    }
                    else
                    {
                        order.OrderId = db.OrderDetail.OrderByDescending(a => a.OrderId).Select(a => a.OrderId).First() + 1;
                    }
                    int pId = cart.PersonId.GetValueOrDefault();
                    order.PersonId = pId;
                    order.Quantity = 1;
                    db.OrderDetail.Add(order);

                    Cart tempCart = db.Cart.Find(i);
                    db.Cart.Remove(tempCart);
                }

                db.SaveChanges();

                return RedirectToAction("PlaceOrder");
            }

            return View("Index", "Category");
        }

        /// <summary>
        /// Returns a message for order placed
        /// </summary>
        /// <returns></returns>
        public ActionResult PlaceOrder()
        {
            ViewBag.Message = "Your order has been placed.";

            return View();
        }

    }
}
