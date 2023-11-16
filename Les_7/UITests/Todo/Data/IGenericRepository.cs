using Todo.Data.Entities;

namespace Todo.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        TEntity? GetById(int id);

        void Update(int id, TEntity entity);

        void Delete(int id);

        void Create(TEntity entity);
    }
}