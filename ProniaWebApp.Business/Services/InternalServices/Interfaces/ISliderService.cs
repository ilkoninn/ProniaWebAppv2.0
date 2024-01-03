using ProniaWebApp.Core.Entities;
using ProniaWebApp.MVC.Areas.Manage.ManageViewModels.SliderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Business.Services.InternalServices.Interfaces
{
    public interface ISliderService
    {
        Task<IQueryable<Slider>> ReadAllAsync();
        Task<Slider> ReadIdAsync(int Id);
        Task CreateAsync(CreateSliderVM slider, string env);
        Task UpdateAsync(UpdateSliderVM slider, string env);
        Task DeleteAsync(int id);
    }
}
