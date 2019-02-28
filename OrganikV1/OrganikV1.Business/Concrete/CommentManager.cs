using Microsoft.Extensions.Caching.Memory;
using OrganikV1.Business.Abstract;
using OrganikV1.Dal.Abstract;
using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentsDal _commentsDal;
        private IMemoryCache _memoryCache;

        public CommentManager(ICommentsDal commentsDal,IMemoryCache memoryCache)
        {
            _commentsDal = commentsDal;
            _memoryCache = memoryCache;
        }
        public void Add(Comments comment)
        {
            _commentsDal.Add(comment);
        }

        public void Delete(int commentId)
        {
            _commentsDal.Delete(new Comments { commentId = commentId });
        }

        public List<Comments> GetAllComments(int productId)
        {
            return _commentsDal.GetList(c => c.productId == productId && c.activeted == true && c.isDeleted == false);
        }

        public List<Comments> GetbyUserId(string userId)
        {
            return _commentsDal.GetList(c => c.userId == userId);
        }

        public Comments GetComment(int commentId)
        {
            return _commentsDal.Get(c => c.commentId == commentId);
        }

        public void RemoveCache()
        {
            throw new NotImplementedException();
        }

        public void Update(Comments comment)
        {
             _commentsDal.Update(comment);
        }
    }
}
