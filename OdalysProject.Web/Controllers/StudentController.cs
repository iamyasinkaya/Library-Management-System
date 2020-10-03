using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;

namespace OdalysProject.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _studentRepository.GetAllAsync());
        }

        public IActionResult GetRentBook(int Id)
        {
            var result = _studentRepository.GetRentBook(Id);

            return View(result);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.CreateAsync(student);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
