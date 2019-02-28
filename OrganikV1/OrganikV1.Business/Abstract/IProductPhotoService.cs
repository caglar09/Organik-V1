using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Business.Abstract
{
   public interface IProductPhotoService
    {
        List<ProductPhoto> GetAll();
        List<ProductPhoto> GetProductPhotoList(int productId);

        ProductPhoto GetPhoto(int id);
        int productPhotoCount(int productId);

        void Add(List<ProductPhoto> photo);
        void Update(ProductPhoto photo);
        void Delete(int photoId);
        void RemoveCache();
    }
}
