using _0_FrameWork.Application;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Delete(int id);
        OperationResult Restore(int id);
        EditSlide GetDetails(int id);
        List<SlideViewModel> GetList();

    }
}
