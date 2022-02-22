﻿using System.ComponentModel.DataAnnotations;

namespace FamilyFinancesApp.Data.Models
{
    public abstract class Operation
    {
        public virtual int Id { get; set; }

        public virtual decimal Amount { get; set; }

        [Required]
        public virtual DateTime SpendingDate { get; set; }
    }
}