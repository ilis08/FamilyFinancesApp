using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FamilyFinancesApp.Data.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Money { get; set; } = decimal.Zero;

        [Required]
        [StringLength(450)]
        public string? UserId { get; set; }

        public IdentityUser? User;

        public IEnumerable<IncomeType>? IncomeTypes { get;set; }

        public IEnumerable<SpendingType>? SpendingTypes { get; set; }
    }
}
