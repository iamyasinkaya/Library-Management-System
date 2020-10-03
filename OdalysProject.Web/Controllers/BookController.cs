using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;
using OdalysProject.Web.Validator;

namespace OdalysProject.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger _logger;
        public BookController(IBookRepository bookRepository, ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _bookRepository.GetAllAsync());
        }

        [HttpGet]

        public IActionResult Create()
        {
            List<SelectListItem> categories = (from i in _applicationDbContext.Category.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.CategoryId.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;


            List<SelectListItem> publishers = (from i in _applicationDbContext.Publisher.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.PublisherId.ToString()
                                               }).ToList();

            ViewBag.Publishers = publishers;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Book book)
        {

            if (ModelState.IsValid)
            {
                await _bookRepository.CreateAsync(book);
                _logger.LogInformation("Kullanıcı başarılı şekilde oluşturuldu.");
            }
            else
            {
                _logger.LogError("Kullanıcı oluşturulamadı.");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? Id)
        {
            return View(await _bookRepository.GetByIdAsync(Id.Value));
        }

        [HttpPost]


        public async Task<IActionResult> Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.DeleteAsync(Id);
                _logger.LogInformation("Kullanıcı başarıyla silindi.");

            }
            else
            {
                _logger.LogError("Kullanıcı Silinemedi.");
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult DownloadExcelDocument()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Book");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "BookId";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "ISBN";
                worksheet.Cell(currentRow, 4).Value = "Quantity";
                worksheet.Cell(currentRow, 5).Value = "Description";
                worksheet.Cell(currentRow, 6).Value = "BookStatus";


                foreach (var book in _applicationDbContext.Book.ToList())
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = book.BookId;
                    worksheet.Cell(currentRow, 2).Value = book.Name;
                    worksheet.Cell(currentRow, 3).Value = book.ISBN;
                    worksheet.Cell(currentRow, 4).Value = book.Quantity;
                    worksheet.Cell(currentRow, 5).Value = book.Desciption;
                    worksheet.Cell(currentRow, 6).Value = book.BookStatus;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "books.xlsx");
                }
            }
        }


        
        public async Task<IActionResult> Details(int Id)
        {
            return View(await _bookRepository.GetByIdAsync(Id));
        }


    }
}
