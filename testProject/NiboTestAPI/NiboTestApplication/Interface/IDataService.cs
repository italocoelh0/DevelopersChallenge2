using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Interface
{
    public interface IDataService
    {
        public string DataImport(DataContext context, DtoDataImport dto);

        public List<Transaction> DataSelect(DataContext context, DtoDataSelect dto);
    }
}
