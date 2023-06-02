using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : BaseRepository<Slide, int>, ISlideRepository
    {
        private readonly ShopContext _ctx;

        public SlideRepository(ShopContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public EditSlide GetDetails(int id)
        {
            return _ctx.slides.Select(c => new EditSlide
            {
                Id=c.Id,
                Heading = c.Heading,
                Title=c.Title,
                Text=c.Text,
                BtnText=c.BtnText,
                Picture=c.Picture,
                PictureAlt=c.PictureAlt,
                PictureTitle=c.PictureTitle,
                Link=c.Link

            }).FirstOrDefault(c=>c.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _ctx.slides.Select(c => new SlideViewModel
            {
                Id=c.Id,
                Heading = c.Heading,
                Title=c.Title,
                Picture=c.Picture,
                IsDeleted=c.IsDeleted

            }).ToList();
        }
    }
}
