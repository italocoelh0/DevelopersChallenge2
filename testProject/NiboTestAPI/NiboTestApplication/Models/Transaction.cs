using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NiboTestApplication.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int? TransactionTypeId { get; set; }
        public decimal TransactionValue { get; set; }
        public string Description { get; set; }
        public ulong AccountId { get; set; }
        public DateTime? DatePosted { get; set; }
        public Account Account { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
