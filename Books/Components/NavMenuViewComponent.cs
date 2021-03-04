using Books.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;

        public NavMenuViewComponent (IBookRepository b)
        {
            repository = b;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["category"];
            
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
