using Microsoft.AspNetCore.Mvc;
using ProniaWebApp.Business.Services.InternalServices.Interfaces;
using ProniaWebApp.Core.Entities;

namespace ProniaWebApp.MVC.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _service;

        public SliderViewComponent(ISliderService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IQueryable<Slider> sliders = await _service.ReadAllAsync(); 

            return View(sliders);
        }
    }
}
