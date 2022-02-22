using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinancesApp.Data.Models
{
    public class Spending : Operation
    {
        public int SpendingTypeId { get; set; }

        public SpendingType? SpendingType { get; set; }
    }
}
