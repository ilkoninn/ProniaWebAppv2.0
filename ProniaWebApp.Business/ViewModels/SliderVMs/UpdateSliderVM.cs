using Microsoft.AspNetCore.Http;
using ProniaWebApp.MVC.Areas.Manage.ManageViewModels.CommonVMs;

namespace ProniaWebApp.MVC.Areas.Manage.ManageViewModels.SliderVMs
{
    public class UpdateSliderVM : BaseEntityVM
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Discount { get; set; }
        public IFormFile? file { get; set; }
    }
}
