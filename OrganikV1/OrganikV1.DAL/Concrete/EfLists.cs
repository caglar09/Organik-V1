using OrganikV1.Core;
using OrganikV1.Dal.Abstract;
using OrganikV1.Entities;
using OrganikV1.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Dal.Concrete
{
    public class EfLists
    {
        public class EfCategoriesDal : EntityRepository<Categories, OrganikV1DbContext>, ICategoryDal
        {
        }
        public class EfProductsDal : EntityRepository<Products, OrganikV1DbContext>, IProductsDal
        {
        }

        public class EfProductsPhotoDal : EntityRepository<ProductPhoto, OrganikV1DbContext>, IProductPhotoDal
        {
        }

        public class EfCommentsDal : EntityRepository<Comments, OrganikV1DbContext>, ICommentsDal
        {
        }

        public class EfUsersDal : EntityRepository<CustomUser, CustomIdentityDbContext>, IUserDal
        {
        }
    }
}
