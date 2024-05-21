using Business.Service.Abstracts;
using Core.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DogMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDogService _dogService;

        public HomeController(IDogService dogService)
        {
            _dogService = dogService;
        }

        public IActionResult Index()
        {
            var dogs = _dogService.GetAllDogs();
            return View(dogs);
        }
    }
}
