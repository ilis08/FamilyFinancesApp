using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinancesApp.Data.Models
{
    public class SpendingType : OperationType
    { 

        public IEnumerable<Spending>? Spendings { get; set; }
    }
}
