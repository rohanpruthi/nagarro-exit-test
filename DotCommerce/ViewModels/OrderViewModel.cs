using DotCommerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotCommerce.ViewModels
{
    public class OrderViewModel
    {
        //[Key]
        //public int Id { get; set; } 
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Product { get; set; }
        public List<string> Variant { get; set; }
        //public string Price { get; set; }
        //[Key]
        public int OrderId { get; set; }
        public List<int> CartId { get; set; }
    }
}