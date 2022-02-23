using FamilyFinancesApp.Data;
using FamilyFinancesApp.Repository;
using FamilyFinancesApp.Repository.IncomeRep;
using FamilyFinancesApp.Repository.SpendingRep;
using FamilyFinancesApp.Repository.UserInfoRep;

namespace FamilyFinancesApp.UnitOfWorkFolder
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private IncomeRepository? incomeRepository;
        private SpendingRepository? spendingRepository;
        private UserInfoRepository? userInfoRepository;

        public IncomeRepository Income
        {
            get
            {
                if (incomeRepository == null)
                    incomeRepository = new IncomeRepository(context);
                return incomeRepository;
            }
        }

        public SpendingRepository Spending
        {
            get
            {
                if(spendingRepository == null)
                    spendingRepository = new SpendingRepository(context);
                return spendingRepository;
            }
        }
        public UserInfoRepository UserInfo
        {
            get
            {
                if(userInfoRepository == null)
                    userInfoRepository = new UserInfoRepository(context);
                return userInfoRepository;
            }
        }



        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        
        public void Dispose()
        {
            
            Dispose(true);
           
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                
            }
            
            disposed = true;
        }
    }
}
