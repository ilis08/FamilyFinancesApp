using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;

namespace FamilyFinancesApp.Repository.IncomeRep
{
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }
    }
}
