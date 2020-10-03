using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;

namespace OdalysProject.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;


        public AuthorController(IAuthorRepository authorRepository, ApplicationDbContext applicationDbContext = null, ILogger<AuthorController> logger = null)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _authorRepository.GetAllAsync());
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
