using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Models;
using System.Collections.Generic;

namespace NiboTestApplication.Interface
{
    public interface IAccountService
    {
        public string CreateAccount(DataContext context, Account dto);

        public List<Account> ReadAccounts(DataContext context, DtoAccountRead dto);

        public string UpdateAccount(DataContext context, Account dto);

        public string DeleteAccount(DataContext context, ulong id);
    }
}
