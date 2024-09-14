﻿using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class TransactionTypes
    {
        [Key]
        public required int TransactionTypeId { get; set; }
        public required string TransactionTypeNames { get; set; }
        public string Description { get; set; }

    }
}