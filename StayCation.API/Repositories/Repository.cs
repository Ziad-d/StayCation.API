using Microsoft.EntityFrameworkCore;
using StayCation.API.Data;
using StayCation.API.Models;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StayCation.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task AddRange(List<T> list)
        {
            await _context.Set<T>().AddRangeAsync(list);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var query = GetAll().Where(predicate);
            if (typeof(T) == typeof(User))
            {
                query = query.Include(u => ((User)(object)u).UserRoles);
            }
            return query;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, string model)
        {
            IQueryable<T> query = _context.Set<T>().Include(model).Where(predicate).AsNoTracking();
            var result = (IEnumerable<T>)query;//.ToList();
            return result;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var result = await query.ToListAsync();

            return result;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.Deleted).AsNoTracking();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public T GetWithTrackinByID(int id)
        {
            return _context.Set<T>()
                    .Where(x => !x.Deleted && x.Id == id)
                    .AsTracking()
                    .FirstOrDefault();
        }

        public async Task<T> First(Expression<Func<T, bool>> predicate)
        {
            return await Get(predicate).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Add_Range(List<T> list)
        {
            _context.Set<T>().AddRange(list);
        }
    }
}
