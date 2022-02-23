using FamilyFinancesApp.Data;
using FamilyFinancesApp.UnitOfWorkFolder;
using System.Linq.Expressions;

namespace FamilyFinancesApp.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
		protected readonly ApplicationDbContext repositoryContext;
		protected readonly IUnitOfWork unitOfWork;

        public BaseRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork)
        {
            this.repositoryContext = repositoryContext;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> FindAll() => repositoryContext.Set<T>();

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => repositoryContext.Set<T>()
																										.Where(expression);
		public void Create(T entity) => repositoryContext.Set<T>().Add(entity);

		public void Update(T entity) => repositoryContext.Set<T>().Update(entity);

		public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);
	}
}
