using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BL.Classes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private SchoolDBEntities _ctx;
        private DbSet<TEntity> _set;
        public Repository(SchoolDBEntities ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<TEntity>();
        }
        public bool AddEntity(TEntity entity)
        {
            _set.Add(entity);
            return _ctx.SaveChanges() > 0;
        }

        public bool DeleteEntity(TEntity entity)
        {
           _set.Remove(entity);
            return _ctx.SaveChanges() > 0;
        }
        public List<TEntity> GetAllBind()
        {
            return GetAll().ToList();
        }
        public IQueryable<TEntity> GetAll()
        {
            return _set;
        }
        public TEntity GetByID(int id)
        {
            return _set.Find(id);
        }
        public bool UpdateEntity(TEntity entity)
        {
            _set.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;
            return _ctx.SaveChanges() > 0;
        }

        public int MaxId(TEntity entity)
        {
            return _ctx.Set<TEntity>().Count()+1;
        }

        public void delete(Expression<Func<TEntity,bool>> Predicate)
        {
            var entities= _set.Where(Predicate);
            _set.RemoveRange(entities);
            _ctx.SaveChanges();
        }
    }
}
