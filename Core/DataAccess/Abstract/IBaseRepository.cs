using Core.Entitties.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
    }
}
