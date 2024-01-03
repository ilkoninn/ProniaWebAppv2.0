using ProniaWebApp.Business.Exceptions.Common;
using ProniaWebApp.Business.Exceptions.SliderExceptions;
using ProniaWebApp.Business.Helpers;
using ProniaWebApp.Business.Services.InternalServices.Interfaces;
using ProniaWebApp.Core.Entities;
using ProniaWebApp.DAL.Repositories.Interfaces;
using ProniaWebApp.MVC.Areas.Manage.ManageViewModels.SliderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Business.Services.InternalServices.Abstractions
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _rep;

        public SliderService(ISliderRepository rep)
        {
            _rep = rep;
        }

        public async Task CreateAsync(CreateSliderVM slider, string env)
        {
            bool checkSameTitle = await _rep.ReadIdAsync(checkExpression: x => x.Title == slider.Title) != null;
            bool checkSameSubTitle = await _rep.ReadIdAsync(checkExpression: x => x.SubTitle == slider.SubTitle) != null;

            if (checkSameTitle)
            {
                throw new SliderArgumentException("There is a slider with same title in the table!", nameof(slider.Title));
            }
            if (checkSameSubTitle)
            {
                throw new SliderArgumentException("There is a slider with same subtitle in the table!", nameof(slider.SubTitle));
            }

            if (slider.file is not null)
            {
                if (!slider.file.CheckLength(3097152))
                {
                    throw new SliderArgumentException("Image size must be lower than 3MB", nameof(slider.file));
                }
                if (!slider.file.CheckType("image/"))
                {
                    throw new SliderArgumentException("File type must be image!", nameof(slider.file));
                }
            }
            else
            {
                throw new SliderArgumentException("You must be upload a photo for slider!(1920x1080)!", nameof(slider.file));
            }

            if (slider.Discount == null)
            {
                throw new SliderArgumentException("You must be give number for discount field!", nameof(slider.Discount));
            }


            Slider newSlider = new()
            {
                Title = slider.Title,
                SubTitle = slider.SubTitle,
                Discount = slider.Discount,
                ImgUrl = slider.file.Upload(env, @"\Upload\SliderImages\"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            await _rep.CreateAsync(newSlider);
            await _rep.SaveChangeAsync();
        }

        public async Task<IQueryable<Slider>> ReadAllAsync()
        {
            var result = await _rep.ReadAllAsync();

            return result;
        }

        public async Task<Slider> ReadIdAsync(int Id)
        {
            var result = CheckSlider(Id);

            return await result;
        }

        public async Task UpdateAsync(UpdateSliderVM slider, string env)
        {
            Slider oldSlider = await CheckSlider(slider.Id);

            bool checkSameTitle = await _rep.ReadIdAsync(checkExpression: x => x.Title == slider.Title && x.Id != slider.Id) != null;
            bool checkSameSubTitle = await _rep.ReadIdAsync(checkExpression: x => x.SubTitle == slider.SubTitle && x.Id != slider.Id) != null;

            if (checkSameTitle)
            {
                throw new SliderArgumentException("There is a slider with same title in the table!", nameof(slider.Title));
            }
            if (checkSameSubTitle)
            {
                throw new SliderArgumentException("There is a slider with same subtitle in the table!", nameof(slider.SubTitle));
            }

            if(slider.file is not null)
            {
                if (slider.file.CheckLength(3097152))
                {
                    throw new SliderArgumentException("Image size must be lower than 3MB", nameof(slider.file));
                }
                if (slider.file.CheckType("image/"))
                {
                    throw new SliderArgumentException("File type must be image!", nameof(slider.file));
                }

                slider.file.Delete(env, @"\Upload\SliderImages\");
                oldSlider.ImgUrl = slider.file.Upload(env, @"\Upload\SliderImages\");
            }

            if (slider.Discount == null)
            {
                throw new SliderArgumentException("You must be give number for discount field!", nameof(slider.Discount));
            }


            oldSlider.Title = slider.Title;
            oldSlider.SubTitle = slider.SubTitle;
            oldSlider.Discount = slider.Discount;
            oldSlider.CreatedDate = oldSlider.CreatedDate;
            oldSlider.UpdatedDate = DateTime.Now;

            await _rep.UpdateAsync(oldSlider);
            await _rep.SaveChangeAsync();
        }
        public async Task DeleteAsync(int Id)
        {
            CheckSlider(Id);

            await _rep.DeleteAsync(Id);
            await _rep.SaveChangeAsync();
        }

        public async Task<Slider> CheckSlider(int Id)
        {
            if (Id <= 0) throw new NegativeIdException();
            var result = await _rep.ReadIdAsync(Id: Id);
            if (result is null) throw new ObjectNotFoundException();

            return result; 
        }

    }
}
