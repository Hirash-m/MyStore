using ShopManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideRepository : IRepository<ShopManagement.Domain.SlideAgg.Slide, int>
    {
        EditSlide GetDetails(int id);
        List<SlideViewModel> GetList();
    }
}
