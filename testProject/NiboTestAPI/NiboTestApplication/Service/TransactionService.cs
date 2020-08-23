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
    public class TransactionService : iTransactionService
    {
        public TransactionService(iUtilsService utils)
        {
            _utils = utils;
        }

        public iUtilsService _utils { get; set; }

        public string ImportTransactiosFile(DataContext context, DtoImportFiles dto)
        {
            try
            {
                foreach (var file in dto.FileList)
                {
                    string[] ofxFileText;
                    using (MemoryStream memory = new MemoryStream(file))
                    {
                        using (StreamReader reader = new StreamReader(memory))
                        {
                            ofxFileText = reader.ReadToEnd().Split(new char[] { '\r', '\n' });
                        };
                    };

                    string xmlStr = _utils.ConvertOFXtoXml(ofxFileText);
                    DtoData dados = _utils.ConvertXmltoObject<DtoData>(xmlStr);

                    // Verify if exists an account with the same information to avoid data duplicity
                    if (context.Accounts.Where(w => w.AccountId == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID
                                               && w.AccountType == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTTYPE
                                               & w.BankId == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.BANKID
                                              ).Count() == 0
                       )
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

                        // Try to get transaction type identifier
                        int transactionTypeId = context.TransactionTypes.Where(w => w.TransactionTypeDesc == trn.TRNTYPE).Select(s => s.TransactionTypeId).FirstOrDefault();

                        // If transaction type not exists, add new transactino type
                        if (transactionTypeId == 0)
                        {
                            context.TransactionTypes.Add(new TransactionType { TransactionTypeDesc = trn.TRNTYPE });

                            context.SaveChanges();
                        }

                        // get transaction type identifier
                        transactionTypeId = context.TransactionTypes.Where(w => w.TransactionTypeDesc == trn.TRNTYPE).Select(s => s.TransactionTypeId).FirstOrDefault();

                        // Verify if exists a transaction with the same information to avoid data duplicity
                        if (context.Transactions.Where(w => w.AccountId == dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID
                                                   && w.TransactionTypeId == transactionTypeId
                                                   && w.TransactionValue == trn.TRNAMT
                                                   && w.Description == trn.MEMO
                                                   && w.DatePosted == dataPosted
                                                  ).Count() == 0
                        )
                            context.Transactions.Add(new Transaction
                            {
                                AccountId = dados.OFX.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID,
                                TransactionTypeId = transactionTypeId,
                                TransactionValue = trn.TRNAMT,
                                Description = trn.MEMO,
                                DatePosted = dataPosted
                            });
                    }

                    context.SaveChanges();
                }
                return "Dados inseridos com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TransactionType> ReadTransactionTypes(DataContext context)
        {
            try
            {
                return context.TransactionTypes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateTransaction(DataContext context, Transaction dto)
        {
            try
            {
                // Transaction 'DEBIT'
                if (dto.TransactionTypeId == 1 && dto.TransactionValue > 0)
                {
                    dto.TransactionValue = dto.TransactionValue * -1;
                }

                var _trans = new Transaction
                {
                    AccountId = dto.AccountId,
                    DatePosted = dto.DatePosted,
                    TransactionTypeId = dto.TransactionTypeId,
                    TransactionValue = dto.TransactionValue,
                    Description = dto.Description
                };

                context.Transactions.Add(_trans);

                context.SaveChanges();

                return $"A transação {_trans.Id} foi adicionada com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Transaction> ReadTransactions(DataContext context, DtoTransactionRead dto)
        {
            try
            {
                return context.Transactions
                             .Include(c => c.Account)
                             .Include(c => c.TransactionType)
                             .Where(w => (dto.AccountId != null ? w.AccountId == dto.AccountId : w.AccountId == w.AccountId)
                                      && (dto.InitialDateInterval != null ? w.DatePosted >= dto.InitialDateInterval : w.DatePosted == w.DatePosted)
                                      && (dto.FinalDateInterval != null ? w.DatePosted <= dto.FinalDateInterval : w.DatePosted == w.DatePosted)
                                      && (dto.TransactionTypeId != null ? w.TransactionTypeId == dto.TransactionTypeId : w.TransactionType == w.TransactionType)
                                   ).OrderByDescending(o => o.DatePosted).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateTransaction(DataContext context, Transaction dto)
        {
            try
            {
                // If it's a 'DEBIT' transaction, transaction value must be NEGATIVE value
                // If it's a 'CREDIT' transaction, transaction value must be POSITIVE value
                if ((dto.TransactionTypeId == 1 && dto.TransactionValue > 0) || (dto.TransactionTypeId == 2 && dto.TransactionValue < 0))
                    dto.TransactionValue = dto.TransactionValue * -1;

                var _trans = context.Transactions.Where(w => w.Id == dto.Id).FirstOrDefault();

                _trans.AccountId = dto.AccountId;
                _trans.DatePosted = dto.DatePosted;
                _trans.TransactionTypeId = dto.TransactionTypeId;
                _trans.TransactionValue = dto.TransactionValue;

                context.Transactions.Update(_trans);

                context.SaveChanges();

                return $"A transação {_trans.Id} foi atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteTransaction(DataContext context, int id)
        {
            try
            {
                var _trans = context.Transactions.Where(w => w.Id == id).FirstOrDefault();

                context.Transactions.Remove(_trans);

                context.SaveChanges();

                return $"A transação {id} foi removida com sucesso.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
