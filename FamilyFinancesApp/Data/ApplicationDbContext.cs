using FamilyFinancesApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinancesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo>? UsersInfo { get; set; }
        public DbSet<Income>? Incomes { get; set; }
        public DbSet<IncomeType>? IncomeTypes { get; set;}
        public DbSet<Spending>? Spendings { get; set; }
        public DbSet<SpendingType>? SpendingTypes { get; set; }
    }
}