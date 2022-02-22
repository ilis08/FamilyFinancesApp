using FamilyFinancesApp.Data;

namespace FamilyFinancesApp.Repository.SpendingRep
{
    public class SpendingRepository : BaseRepository<SpendingRepository>, ISpendingRepository
    {
        public SpendingRepository(ApplicationDbContext _repositoryContext) : base(_repositoryContext)
        {
        }
    }
}
