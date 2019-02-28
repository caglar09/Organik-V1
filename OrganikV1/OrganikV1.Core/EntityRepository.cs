using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OrganikV1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrganikV1.Core
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, new()
        where TContext : DbContext,new()
    {
        //private readonly DbContext _context;

        //public EntityRepository()
        //{
        //    using (var context = new TContext())
        //    {
        //        _context = context;
        //    }

        //}

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context=new TContext())
            {
                return _context.Set<TEntity>().SingleOrDefault(filter);
            }
            

        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return filter != null ?
                 _context.Set<TEntity>().FirstOrDefault(filter)
                 : _context.Set<TEntity>().FirstOrDefault();
            }
            
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return filter == null ?
                 _context.Set<TEntity>().ToList()
                 : _context.Set<TEntity>().Where(filter).ToList();
            }

            
        }

        public void Add(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var addEntity = _context.Entry(entity);
                addEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
            
        }

        public void Delete(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var deleteEntity = _context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            }
            
        }

        public void Update(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var updateEntity = _context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                _context.SaveChanges();
            }
            
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return filter != null ? _context.Set<TEntity>().Count(filter) : _context.Set<TEntity>().Count();
            }
           
        }

        
    }
}
