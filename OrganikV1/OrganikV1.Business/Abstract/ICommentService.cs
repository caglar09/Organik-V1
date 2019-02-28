using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Business.Abstract
{
   public interface ICommentService
    {
        List<Comments> GetAllComments(int productId);

        /*Comments getProduct(int productId);

        List<Comments> GetbyCategories(int catId);*/
        List<Comments> GetbyUserId(string userId);

        Comments GetComment(int commentId);

       /* int productListCount();

        int userProductCount(string userId);*/

        void Add(Comments comment);
        void Update(Comments comment);
        void Delete(int commentId);
        void RemoveCache();
    }
}
