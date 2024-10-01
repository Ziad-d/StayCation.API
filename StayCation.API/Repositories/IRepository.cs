using StayCation.API.Models;
using System.Linq.Expressions;

namespace StayCation.API.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, string model);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task AddRange(List<T> list);
        void Add_Range(List<T> list);
        Task<T> GetByIDAsync(int id);
        T GetWithTrackinByID(int id);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        Task<T> First(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
