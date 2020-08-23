using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Interface;
using NiboTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NiboTestApplication.Service
{
    public class AccountService : IAccountService
    {
        public string CreateAccount(DataContext context, Account dto)
        {
            try
            {
                var _acc = new Account
                {
                    AccountType = dto.AccountType,
                    BankId = dto.BankId
                };

                context.Accounts.Add(_acc);

                context.SaveChanges();

                return $"A conta {_acc.AccountId} foi adicionada com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Account> ReadAccounts(DataContext context, DtoAccountRead dto)
        {
            try
            {
                return context.Accounts
                          .Where(w => (dto.AccountId != null ? w.AccountId == dto.AccountId : w.AccountId == w.AccountId)
                                   && (!string.IsNullOrEmpty(dto.AccountType) ? w.AccountType == dto.AccountType : w.AccountType == w.AccountType)
                                   && (dto.BankId != null ? w.BankId == dto.BankId : w.BankId == w.BankId))
                          .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string UpdateAccount(DataContext context, Account dto)
        {
            try
            {
                var _acc = context.Accounts.Where(w => w.AccountId == dto.AccountId).FirstOrDefault();

                _acc.AccountType = dto.AccountType;
                _acc.BankId = dto.BankId;

                context.Accounts.Update(_acc);

                context.SaveChanges();

                return $"A conta {_acc.AccountId} foi atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteAccount(DataContext context, ulong id)
        {
            try
            {
                var _trans = context.Transactions.Where(w => w.AccountId == id).ToList();
                var _acc = context.Accounts.Where(w => w.AccountId == id).FirstOrDefault();

                context.Transactions.RemoveRange(_trans);
                context.Accounts.Remove(_acc);

                context.SaveChanges();

                return $"A conta {id} e todas as suas transações foram deletadas com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
