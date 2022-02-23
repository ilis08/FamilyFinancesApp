using System.ComponentModel.DataAnnotations;

namespace FamilyFinancesApp.Data.Models
{
    public abstract class Operation
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual decimal Amount { get; set; }

        [Required]
        public virtual DateTime OperationDate { get; set; }

    }
}
