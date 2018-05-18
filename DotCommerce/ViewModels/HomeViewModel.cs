using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotCommerce.ViewModels
{
    public class HomeViewModel
    {   
        public List<int> Id { get; set; }
        public string Category { get; set; }
        public List<string> Title { get; set; }
        public List<string> ImageUrl { get; set; }
    }
}