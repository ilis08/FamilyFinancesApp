using FamilyFinancesApp.Data;

namespace FamilyFinancesApp.Repository.IncomeRep
{
    public class IncomeRepository : BaseRepository<IncomeRepository>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext _repositoryContext) : base(_repositoryContext)
        {
        }
    }
}
