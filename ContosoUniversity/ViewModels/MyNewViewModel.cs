using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;

namespace ContosoUniversity.ViewModels
{
    public class MyNewViewModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string CurrentSort { get; set; }

        public string NameSortParm { get; set; }

        public string DateSortParm { get; set; }

        public string CurrentFilter { get; set; }

        public PagedList.IPagedList<Student> stu { get; set; }

    }
}