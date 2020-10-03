using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;

namespace OdalysProject.Web.Controllers
{
    public class RentBookController : Controller
    {
        private readonly IRentBookRepository _rentBookRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public RentBookController(IRentBookRepository rentBookRepository, ApplicationDbContext applicationDbContext)
        {
            _rentBookRepository = rentBookRepository ?? throw new ArgumentNullException(nameof(rentBookRepository));
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _rentBookRepository.GetAllAsync());
        }

        [HttpGet]

        public IActionResult Create()
        {
            List<SelectListItem> books = (from i in _applicationDbContext.Book.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.BookId.ToString()
                                               }).ToList();

            ViewBag.Books = books;


            List<SelectListItem> students = (from i in _applicationDbContext.Student.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.StudentNumber,
                                                   Value = i.StudentId.ToString()
                                               }).ToList();

            ViewBag.Students = students;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(RentBook rentBook)
        {
            if (ModelState.IsValid)
            {
                await _rentBookRepository.CreateAsync(rentBook);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
