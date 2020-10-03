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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAllAsync());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateAsync(category);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetBooks(int Id)
        {
            var result = _categoryRepository.GetBooks(Id);

            return View(result);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? Id)
        {
            return View(await _categoryRepository.GetByIdAsync(Id.Value));
        }

        [HttpPost]


        public async Task<IActionResult> Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.DeleteAsync(Id);


            }

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]

        public async Task<IActionResult> Update(int Id)
        {
            return View(await _categoryRepository.GetByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(category);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
