using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.Repository.UserInfoRep;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinancesApp.Repository.UserInfoRep
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }

        public async Task<UserInfo> CreateUserInfoAsync(string userId)
        {
            var userInfo = new UserInfo()
            {
                UserId = userId,
            };

            Create(userInfo);

            await unitOfWork.SaveAsync();

            return userInfo;
        }

        public async Task DeleteUserInfoAsync(string userId)
        {
            var userInfo = await FindByCondition(x => x.UserId == userId).FirstOrDefaultAsync();

            if (userInfo is not null)
            {
                Delete(userInfo);
            }

            await unitOfWork.SaveAsync();
        }

        public async Task<UserInfo> GetUserInfoAsync(string userId)
        {
            var userInfo = await FindByCondition(x => x.UserId == userId).FirstOrDefaultAsync();

            if (userInfo is null)
            {
                throw new Exception();
            }

            return userInfo;
        }
    }
}
