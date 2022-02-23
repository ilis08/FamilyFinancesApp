using FamilyFinancesApp.Data;
using FamilyFinancesApp.Repository;
using FamilyFinancesApp.Repository.IncomeRep;
using FamilyFinancesApp.Repository.IncomeTypeRep;
using FamilyFinancesApp.Repository.SpendingRep;
using FamilyFinancesApp.Repository.SpendingTypeRep;
using FamilyFinancesApp.Repository.UserInfoRep;

namespace FamilyFinancesApp.UnitOfWorkFolder
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private IncomeRepository? incomeRepository;
        private SpendingRepository? spendingRepository;
        private UserInfoRepository? userInfoRepository;
        private IncomeTypeRepository? incomeTypeRepository;
        private SpendingTypeRepository? spendingTypeRepository;

        public IncomeRepository Income
        {
            get
            {
                if (incomeRepository == null)
                    incomeRepository = new IncomeRepository(context, this);
                return incomeRepository;
            }
        }

        public SpendingRepository Spending
        {
            get
            {
                if(spendingRepository == null)
                    spendingRepository = new SpendingRepository(context, this);
                return spendingRepository;
            }
        }
        public UserInfoRepository UserInfo
        {
            get
            {
                if(userInfoRepository == null)
                    userInfoRepository = new UserInfoRepository(context, this);
                return userInfoRepository;
            }
        }

        public SpendingTypeRepository SpendingType
        {
            get
            {
                if (spendingTypeRepository == null)
                    spendingTypeRepository = new SpendingTypeRepository(context, this);
                return spendingTypeRepository;
            }
        }

        public IncomeTypeRepository IncomeType
        {
            get
            {
                if (incomeTypeRepository == null)
                    incomeTypeRepository = new IncomeTypeRepository(context, this);
                return incomeTypeRepository;
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
