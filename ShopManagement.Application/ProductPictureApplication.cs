using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }
        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            if (_productPictureRepository.Exist(c => c.Picture == command.Picture && c.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var productPicture = new ProductPicture(command.Picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Succeeded();

        }

        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            productPicture.Delete();
            _productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productPictureRepository.Exist(c => c.Picture == command.Picture 
            && c.ProductId == command.ProductId
            && c.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            productPicture.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            _productPictureRepository.SaveChanges();
            return operation.Succeeded();



        }

        public EditProductPicture GetDetails(int id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel command)
        {
            return _productPictureRepository.Search(command);
        }
    }
}
