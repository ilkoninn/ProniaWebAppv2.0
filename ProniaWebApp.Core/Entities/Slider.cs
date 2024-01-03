using ProniaWebApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Core.Entities
{
    public class Slider : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImgUrl { get; set; }
        public int Discount { get; set; }
    }
}
