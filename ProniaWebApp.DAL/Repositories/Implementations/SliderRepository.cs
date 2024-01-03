using ProniaWebApp.Core.Entities;
using ProniaWebApp.DAL.Context;
using ProniaWebApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.DAL.Repositories.Implementations
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context) { }
    }
}
