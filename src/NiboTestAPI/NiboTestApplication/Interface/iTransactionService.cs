using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Interface
{
    public interface iTransactionService
    {
        public string ImportTransactiosFile(DataContext context, DtoImportFiles dto);

        public List<TransactionType> ReadTransactionTypes(DataContext context);

        public string CreateTransaction(DataContext context, Transaction dto);

        public List<Transaction> ReadTransactions(DataContext context, DtoTransactionRead dto);

        public string UpdateTransaction(DataContext context, Transaction dto);

        public string DeleteTransaction(DataContext context, int id);
    }
}
