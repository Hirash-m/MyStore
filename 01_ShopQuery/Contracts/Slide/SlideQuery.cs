using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ShopQuery.Contracts.Slide
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _ctx;

        public SlideQuery(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public List<SlideQueryModel> GetSlides()
        {
           return _ctx.slides.Where(c=>c.IsDeleted==false).Select(c=> new SlideQueryModel
            {
               Heading= c.Heading,
               Title= c.Title,
               Text= c.Text,
               Picture= c.Picture,
               PictureAlt= c.PictureAlt,
               PictureTitle= c.PictureTitle,
               BtnText= c.BtnText,
               Link=c.Link

            }).ToList();   
        }
    }
}
