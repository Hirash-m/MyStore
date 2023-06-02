using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Picture { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }
        [Range(1,int.MaxValue,ErrorMessage =ValidationMessages.IsRequired)]
        public int ProductId { get;  set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
