using DotCommerce.Models;
using DotCommerce.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DotCommerce.Controllers
{
    public class HomeController : Controller
    {
        private DotCommerceDataEntities db = new DotCommerceDataEntities();

        /// <summary>
        /// Displays 3 top selling products of top 3 selling categories
        /// and 5 products of other categories
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            List<HomeViewModel> homeViewModelList = new List<HomeViewModel>();

            int categoryCount = db.Category.Count();
            const int cartIdInitial = 100;
            for (int cartId = 1; cartId <= 3; cartId++)
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                List<string> title = new List<string>();
                List<string> image = new List<string>();
                List<int> id = new List<int>();
                string catTitle = (from c in db.Category where c.Id.Equals(cartIdInitial + cartId) select c.Title).FirstOrDefault();
                var data = (from p in db.Product
                            join c in db.Category on p.CategoryId equals c.Id
                            where c.Id.Equals(cartIdInitial + cartId)
                            select new { p.Id, p.Title, p.Image }).Distinct().Take(3);
                homeViewModel.Category = catTitle;
                foreach (var item in data)
                {
                    id.Add(item.Id);
                    title.Add(item.Title);
                    image.Add(item.Image);
                    homeViewModel.Id = id;
                    homeViewModel.Title = title;
                    homeViewModel.ImageUrl = image;
                }
                homeViewModelList.Add(homeViewModel);
            }
            for (int cartId = 4; cartId <= categoryCount; cartId++)
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                List<int> id = new List<int>();
                List<string> title = new List<string>();
                List<string> image = new List<string>();
                string categoryTitle = (from c in db.Category where c.Id.Equals(cartId) select c.Title).FirstOrDefault();
                var data = (from p in db.Product
                            join c in db.Category on p.CategoryId equals c.Id
                            where c.Id.Equals(cartIdInitial + cartId)
                            select new { p.Id, p.Title, p.Image }).Distinct().Take(5);
                homeViewModel.Category = categoryTitle;
                foreach (var item in data)
                {
                    id.Add(item.Id);
                    title.Add(item.Title);
                    image.Add(item.Image);
                    homeViewModel.Id = id;
                    homeViewModel.Title = title;
                    homeViewModel.ImageUrl = image;

                }

                homeViewModelList.Add(homeViewModel);
            }

            return View(homeViewModelList);
        }

    }
}