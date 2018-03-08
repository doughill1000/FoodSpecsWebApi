using System.Data.Entity;
using System.Linq;

namespace FoodSpecialsUI.Repository
{
    public abstract class GenericRepository<C,T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>().AsQueryable();
            return query;
        }

        public virtual T GetByID(object id)
        {
            return _entities.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            _entities.Set<T>().Add(entity);
            _entities.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = GetByID(id);
            _entities.Set<T>().Remove(entity);
            _entities.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
        }

    }
}