using Business.Exceptions;
using Business.Service.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DogController : Controller
    {
        private readonly IDogService _dogService;
        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        public IActionResult Index()
        {
            var dogs = _dogService.GetAllDogs();
            return View(dogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dog dog)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _dogService.AddDog(dog);
            }
            catch (ImageContextException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (IMageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileNullReferanceException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existDog = _dogService.GetDog(x => x.Id == id);
            if (existDog == null) return NotFound();
            return View(existDog);
        }

        [HttpPost]
        public IActionResult Update(Dog Dog)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _dogService.UpdateDog(Dog.Id, Dog);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageContextException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (IMageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Business.Exceptions.FileNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existDog = _dogService.GetDog(x => x.Id == id);
            if (existDog == null) return NotFound();
            return View(existDog);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
                _dogService.DeleteDog(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileNullReferanceException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

    }
}
