using OrganikV1.Core;
using OrganikV1.Entities;
using OrganikV1.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Dal.Abstract
{
   public interface IUserDal:IEntityRepository<CustomUser>
    {
    }
}
