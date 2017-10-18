﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP25.Bank.BO
{
    public class BankAccount
    {
        public int Id { get; protected set; }
        public string OwnerName { get; set; }
        public decimal Money { get; protected set; }
        public DateTime CreatedOn { get; protected set; }

        protected BankAccount()
        {

        }

        public BankAccount(string ownerName, decimal money)
            : this()
        {
            OwnerName = ownerName;
            Money = money;
            CreatedOn = DateTime.Now;
        }

        public void Depost(decimal money)
        {
            if (money > 0.0m)
            {
                Money += money;
            }
        }

        public void Withdraw(decimal money)
        {
            if (money > 0.0m && Money - money >= 0.0m)
            {
                Money -= money;
            }
        }
    }
}
