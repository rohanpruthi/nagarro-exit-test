using System.Collections.Generic;
using System.Web.Mvc;

namespace DotCommerce.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryTitle { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public List<SelectListItem> Variants { get; set; }
    }

}