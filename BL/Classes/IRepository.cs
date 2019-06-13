using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Classes
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAllBind();
        IQueryable<TEntity> GetAll();
        TEntity GetByID(int id);
        bool AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
        bool DeleteEntity(TEntity entity);
        int MaxId(TEntity entity);
    }
}
