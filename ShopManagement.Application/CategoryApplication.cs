using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Category;
using ShopManagement.Domain.CategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateCategory command)
        {
            var oparation = new OperationResult();
            if (_categoryRepository.Exist(c=>c.Name ==command.Name))
                return oparation.Failed("امکان ایجاد رکورد تکراری وجود ندارد");


            var category = new Category(command.Name,command.Description,command.Picture,command.PictureAlt,
                                        command.PictureTitle,command.KeyWords,command.MetaDescription,command.Slug);
            _categoryRepository.Create(category);
            _categoryRepository.SaveChanges();
            return oparation.Succeeded();

        }

        public OperationResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditCategory command)
        {
            var oparation = new OperationResult();
            var category = _categoryRepository.GetCategory(command.Id);
            if (category == null)
               return oparation.Failed("دسته بندی مورد نظر وجود ندارد");
            if (_categoryRepository.Exist(c => c.Name == command.Name && c.Id != command.Id))
                return oparation.Failed("نام دسته بندی وارد شده وجود دارد . نام دیگری انتخاب نمایید.");



            category.Edit(command.Name, command.Description, command.Picture, command.PictureAlt,
                          command.PictureTitle, command.KeyWords, command.MetaDescription, command.Slug);
            _categoryRepository.SaveChanges();
            return oparation.Succeeded();

        }

   

        public EditCategory GetCategory(int id)
        {
            var domainCategory = _categoryRepository.GetCategory(id);
            var category = new EditCategory() { 
            Id=domainCategory.Id, Name=domainCategory.Name, Description=domainCategory.Description,
            PictureAlt=domainCategory.PictureAlt,Picture=domainCategory.Picture,KeyWords=domainCategory.KeyWords,
            MetaDescription=domainCategory.MetaDescription,Slug=domainCategory.Slug,PictureTitle=domainCategory.PictureTitle
            };

            return category;
            
        }

        public List<CategoryViewModel> Search(CategorySearchModel command)
        {
            throw new NotImplementedException();
        }
    }
}