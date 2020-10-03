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
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository ?? throw new ArgumentNullException(nameof(publisherRepository));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _publisherRepository.GetAllAsync());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                await _publisherRepository.CreateAsync(publisher);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? Id)
        {
            return View(await _publisherRepository.GetByIdAsync(Id.Value));
        }

        [HttpPost]


        public async Task<IActionResult> Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                await _publisherRepository.DeleteAsync(Id);


            }

            return RedirectToAction(nameof(Index));

        }
    }
}
