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
            var spending = await FindByCondition(x => x.Id == id).Include(x => x.SpendingType).FirstOrDefaultAsync();

            if (spending is null)
            {
                throw new Exception();
            }

            var userInfo = await repositoryContext.Set<UserInfo>().Where(x => x.Id == spending.SpendingType.UserInfoId).FirstOrDefaultAsync();

            if (userInfo is null)
            {
                throw new Exception();
            }

            userInfo.Money += spending.Amount;

            repositoryContext.Set<UserInfo>().Update(userInfo);

            Delete(spending);

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

        public async Task<IEnumerable<Spending>> GetAllSpendingsBySpendingType(int spendingTypeId)
        {
            var spendings = await FindByCondition(x => x.SpendingTypeId == spendingTypeId).Include(x => x.SpendingType).ToListAsync();

            return spendings;
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
            var spendingToUpdate = await GetSpendingAsync(spending.Id);

            var userInfo = await repositoryContext.Set<UserInfo>().Where(x => x.Id == spendingToUpdate.SpendingType.UserInfoId).FirstOrDefaultAsync();

            if (spending.Amount > spendingToUpdate.Amount)
            {
                var amountToOperate = spending.Amount - spendingToUpdate.Amount;
                userInfo.Money -= amountToOperate;
                spendingToUpdate.Amount += amountToOperate;
            }
            else if(spending.Amount < spendingToUpdate.Amount)
            {
                var amountToOperate = spendingToUpdate.Amount - spending.Amount;
                userInfo.Money += amountToOperate;
                spendingToUpdate.Amount -= amountToOperate;
            }

            repositoryContext.Set<UserInfo>().Update(userInfo);

            Update(spendingToUpdate);

            await unitOfWork.SaveAsync();

            return spending;
        }

       public async Task<List<SpendingTypeChart>> GetSpendingChartAsync(int userInfoId)
        {
            var spendingTypes = await unitOfWork.SpendingType.GetAllSpendingTypesAsync(userInfoId);

            var spendingTypeChart = new List<SpendingTypeChart>();

            foreach (var item in spendingTypes)
            {
                var spendings = await unitOfWork.Spending.GetAllSpendingsBySpendingType(item.Id);

                if (spendings is not null)
                {
                    spendingTypeChart.Add(new SpendingTypeChart(item.TypeName, spendings.Count()));
                }
            }

            return spendingTypeChart;
        }
    }
}
