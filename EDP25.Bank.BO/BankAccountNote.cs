using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP25.Bank.BO
{
    public class BankAccountNote
    {
        public int Id { get; protected set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; protected set; }

        public virtual BankAccount Account { get; protected set; }
        public virtual int AccountId { get; protected set; }

        protected BankAccountNote()
        {

        }

        public BankAccountNote(BankAccount account, string note) : this()
        {
            Account = account;
            Account.Notes.Add(this);

            Note = note;
            CreatedOn = DateTime.Now;
        }
    }
}
