using System.Linq.Expressions;
using Trainings.Data.Context;
using Trainings.Data.Repositories.Abstracts;

namespace Trainings.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationContext { get; set; }

        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            this.ApplicationContext = repositoryContext;
        }

        public IQueryable<T>? FindAll() => ApplicationContext.Set<T>();

        public IQueryable<T>? FindByCondition(Expression<Func<T, bool>> expression) =>
            ApplicationContext.Set<T>().Where(expression);

        public void Create(T entity) => ApplicationContext.Set<T>().Add(entity);

        public void Update(T entity) => ApplicationContext.Set<T>().Update(entity);

        public void Delete(T entity) => ApplicationContext.Set<T>().Remove(entity);
    }
}
