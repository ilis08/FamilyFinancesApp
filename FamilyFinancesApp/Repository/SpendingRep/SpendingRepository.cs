using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinancesApp.Repository.SpendingRep
{
    public class SpendingRepository : BaseRepository<Spending>, ISpendingRepository
    {
        public SpendingRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }

        public async Task<Spending> CreateSpendingAsync(Spending spending)
        {
            var userInfo = await repositoryContext.Set<UserInfo>().Where(x => x.Id == spending.SpendingType.UserInfoId).FirstOrDefaultAsync();

            if (userInfo is null)
            {
                throw new Exception();
            }

            userInfo.Money -= spending.Amount;

            repositoryContext.Set<UserInfo>().Update(userInfo);

            Create(spending);

            await unitOfWork.SaveAsync();

            return spending;
        }

        public async Task DeleteSpending(int id)
        {
            var spending = await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (spending is not null)
            {
                Delete(spending);
            }

            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Spending>> GetAllSpendingsAsync(int userInfoId)
        {
            var spending = await FindByCondition(x => x.SpendingType.UserInfoId == userInfoId).Include(x => x.SpendingType).ToListAsync();

            if (spending is not null)
            {
                return spending;
            }

            throw new Exception();
        }

        public async Task<Spending> GetSpendingAsync(int id)
        {
            var spending = await FindByCondition(x => x.Id == id).Include(x => x.SpendingType).FirstOrDefaultAsync();

            if (spending is not null)
            {
                return spending;
            }

            throw new Exception();
        }

        public async Task<Spending> UpdateSpendingAsync(Spending spending)
        {
            Update(spending);

            await unitOfWork.SaveAsync();

            return spending;
        }
    }
}
