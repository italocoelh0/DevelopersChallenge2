using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Dto
{
    public class DtoDataSelect
    {
        public ulong? AccountId { get; set; }
        public DateTime? InitialDateInterval { get; set; }
        public DateTime? EndDateInterval { get; set; }
    }
}
