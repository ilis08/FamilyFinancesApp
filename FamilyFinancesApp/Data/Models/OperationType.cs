using System.ComponentModel.DataAnnotations;

namespace FamilyFinancesApp.Data.Models
{
    public abstract class OperationType
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Operation type field is required")]
        public virtual string? TypeName { get; set; }
    }
}
