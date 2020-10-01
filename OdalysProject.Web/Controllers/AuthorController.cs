using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;

namespace OdalysProject.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ApplicationDbContext _applicationDbContext;


        public AuthorController(IAuthorRepository authorRepository, ApplicationDbContext applicationDbContext = null)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _authorRepository.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorRepository.CreateAsync(author);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            return View(await _authorRepository.GetByIdAsync(Id.Value));
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                await _authorRepository.DeleteAsync(Id);


            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult DownloadExcelDocument()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Author");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "AuthorId";
                worksheet.Cell(currentRow, 2).Value = "FirstName";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "NickName";
                worksheet.Cell(currentRow, 5).Value = "About";
                worksheet.Cell(currentRow, 6).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 7).Value = "DateOfDeath";

                foreach (var author in _applicationDbContext.Author.ToList())
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = author.AuthorId;
                    worksheet.Cell(currentRow, 2).Value = author.Firstname;
                    worksheet.Cell(currentRow, 3).Value = author.Lastname;
                    worksheet.Cell(currentRow, 4).Value = author.Nickname;
                    worksheet.Cell(currentRow, 5).Value = author.About;
                    worksheet.Cell(currentRow, 6).Value = author.DateOfBirth;
                    worksheet.Cell(currentRow, 7).Value = author.DateOfDeath;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "authors.xlsx");


                }

            }
        }
    }
}
