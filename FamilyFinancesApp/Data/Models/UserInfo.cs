using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FamilyFinancesApp.Data.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Money { get; set; }

        public Guid UserId { get; set; }

        public IdentityUser? User;
    }
}
