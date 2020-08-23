using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NiboTestApplication.Models
{
    public class Account
    {
        [Key]
        public ulong AccountId { get; set; }
        public string AccountType { get; set; }
        public int BankId { get; set; }

    }
}
