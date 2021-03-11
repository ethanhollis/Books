using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        public int ItemsPerPage = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //This is the controller -- routes are set in startup for the possible parameters
        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new Books.Models.ViewModels.BookListViewModel
            {
                Books = _repository.Books
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.BookId)
                    .Skip((pageNum - 1) * ItemsPerPage)
                    .Take(ItemsPerPage),

                PagingInfo = new Models.ViewModels.PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = ItemsPerPage,
                    TotalItems = category == null ? _repository.Books.Count() :
                                    _repository.Books.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            }) ;
                

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
