using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Dto
{
    public class DtoTransactionRead
    {
        public ulong? AccountId { get; set; }
        public int? TransactionTypeId { get; set; }
        public DateTime? InitialDateInterval { get; set; }
        public DateTime? FinalDateInterval { get; set; }
    }
}
