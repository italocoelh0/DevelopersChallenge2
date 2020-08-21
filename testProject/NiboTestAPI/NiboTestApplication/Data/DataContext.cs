using Microsoft.EntityFrameworkCore;
using NiboTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
