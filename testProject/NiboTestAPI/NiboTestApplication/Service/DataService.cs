using Microsoft.EntityFrameworkCore;
using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Interface;
using NiboTestApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NiboTestApplication.Service
{
    public class DataService : IDataService
    {
        public DataService(iUtilsService utils)
        {
            _utils = utils;
        }

        public iUtilsService _utils { get; set; }

        public string DataImport(DataContext context, DtoDataImport dto)
        {
            try
            {
                string[] fileText = File.ReadAllLines(@"C:\Users\italo\Desktop\TesteNibo\DevelopersChallenge2\OFX\extrato1.ofx");

                string xmlStr = _utils.ConvertOFXtoXml(fileText);
                DtoData dados = _utils.ConvertXmltoObject<DtoData>(xmlStr);

                // Verify if exists an account with the same information to avoid data duplicity
                if (context.Accounts.Where(w => w.AccountId == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID && w.AccountType == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTTYPE & w.BankId == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.BANKID).Count() == 0)
                    context.Accounts.Add(new Account
                    {
                        AccountId = dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID,
                        AccountType = dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTTYPE,
                        BankId = dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.BANKID
                    });

                foreach (DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN trn in dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN)
                {
                    // Convert the Transaction DTPOSTED to DateTime Type to compare and insert then
                    DateTime dataPosted = _utils.ConvertOfxDateStrtoDateTime(trn.DTPOSTED);

                    // Verify if exists a transaction with the same information to avoid data duplicity
                    if (context.Transactions.Where(w => w.AccountId == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID && w.TransactionType == trn.TRNTYPE && w.TransactionValue == trn.TRNAMT && w.Description == trn.MEMO && w.DatePosted == dataPosted).Count() == 0)
                        context.Transactions.Add(new Transaction
                        {
                            AccountId = dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID,
                            TransactionType = trn.TRNTYPE,
                            TransactionValue = trn.TRNAMT,
                            Description = trn.MEMO,
                            DatePosted = dataPosted
                        });
                }

                context.SaveChanges();

                return "Dados inseridos com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Transaction> DataSelect(DataContext context, DtoDataSelect dto)
        {
            var result = context.Transactions
                   .Include(c => c.Account)
                   .Where(w => (dto.AccountId != null ? w.AccountId == dto.AccountId : w.AccountId == w.AccountId)
                            && (dto.InitialDateInterval != null ? w.DatePosted > dto.InitialDateInterval : w.DatePosted == w.DatePosted)
                            && (dto.EndDateInterval != null ? w.DatePosted < dto.EndDateInterval : w.DatePosted == w.DatePosted)
                         ).ToList();

            return result;
        }
    }
}
