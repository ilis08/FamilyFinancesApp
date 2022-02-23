using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.UserInfoRep
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoAsync(string userId);

        Task DeleteUserInfoAsync(string userId);

        Task<UserInfo> CreateUserInfoAsync(string userId);
    }
}
