using Microsoft.AspNetCore.Mvc;
using ProniaWebApp.Business.Exceptions.SliderExceptions;
using ProniaWebApp.Business.Services.InternalServices.Interfaces;
using ProniaWebApp.Core.Entities;
using ProniaWebApp.MVC.Areas.Manage.ManageViewModels.SliderVMs;

namespace ProniaWebApp.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISliderService _service;

        public SliderController(IWebHostEnvironment environment, ISliderService service)
        {
            _env = environment;
            _service = service;
        }

        // <-- Table Section -->
        public async Task<IActionResult> Table()
        {
            ViewData["Sliders"] = await _service.ReadAllAsync();
            return View();
        }

        // <-- Create Section -->
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM slider)
        {
            try
            {
                await _service.CreateAsync(slider, _env.WebRootPath);
            }
            catch (SliderArgumentException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(slider);
            }

            return RedirectToAction(nameof(Table));
        }

        // <-- Update Section -->
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            Slider oldSlider = await _service.ReadIdAsync(Id);
            UpdateSliderVM slider = new()
            {
                Title = oldSlider.Title,
                SubTitle = oldSlider.SubTitle,
                Discount = oldSlider.Discount,
            };

            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderVM slider)
        {
            try
            {
                await _service.UpdateAsync(slider, _env.WebRootPath);
            }   
            catch (SliderArgumentException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(slider);
            }

            return RedirectToAction(nameof(Table));
        }

        // <-- Detail Section -->
        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            Slider oldSlider = await _service.ReadIdAsync(Id);

            return View(oldSlider);
        }

        // <-- Delete Section -->
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.DeleteAsync(Id);

            return RedirectToAction(nameof(Table));
        }

    }
}
