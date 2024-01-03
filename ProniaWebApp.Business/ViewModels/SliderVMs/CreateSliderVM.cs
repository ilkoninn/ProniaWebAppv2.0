using Microsoft.AspNetCore.Http;

namespace ProniaWebApp.MVC.Areas.Manage.ManageViewModels.SliderVMs
{
    public class CreateSliderVM
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Discount { get; set; }
        public IFormFile? file { get; set; }
    }
}
