using Microsoft.EntityFrameworkCore;
using Todo.Data.Entities;

namespace Todo.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion Fields

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity? entity = _dbContext.Set<TEntity>().Find(id);

            if (entity == null)
            {
                return;
            }

            _dbContext.Set<TEntity>().Remove(entity);

            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity? GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}