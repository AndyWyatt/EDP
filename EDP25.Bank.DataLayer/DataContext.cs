using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP25.Bank.DataLayer
{
    internal class DataContext : DbContext
    {
        public DbSet<BO.BankAccount> Accounts { get; set; }

        public DataContext() : base("Bank")
        {

        }
    }
}
