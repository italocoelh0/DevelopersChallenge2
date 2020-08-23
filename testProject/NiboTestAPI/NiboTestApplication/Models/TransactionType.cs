using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NiboTestApplication.Models
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }
        public string TransactionTypeDesc { get; set; }
    }
}
