using _0_FrameWork.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Category;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get; set; }
        [Range(1000,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public int UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        [Range(1,1000,ErrorMessage = ValidationMessages.IsRequired)]
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
