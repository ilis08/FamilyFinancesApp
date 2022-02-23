using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;

namespace FamilyFinancesApp.Repository.SpendingRep
{
    public class SpendingRepository : BaseRepository<Spending>, ISpendingRepository
    {
        public SpendingRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }
    }
}
