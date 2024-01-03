using Microsoft.Extensions.DependencyInjection;
using ProniaWebApp.Business.Services.InternalServices.Abstractions;
using ProniaWebApp.Business.Services.InternalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Business.Services
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISliderService, SliderService>();
        }
    }
}
