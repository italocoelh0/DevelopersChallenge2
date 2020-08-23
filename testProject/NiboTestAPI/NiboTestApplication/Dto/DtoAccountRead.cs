using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Dto
{
    public class DtoAccountRead
    {
        public ulong? AccountId { get; set; }
        public string AccountType { get; set; }
        public int? BankId { get; set; }
    }
}
