using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP25.Bank.DataLayer
{
    public class Repository : IDisposable
    {
        private DataContext db = new DataContext();

        #region BankAccounts
        public void BankAccountInsert(BO.BankAccount bankAccount)
        {
            db.Accounts.Add(bankAccount);
        }

        public BO.BankAccount BankAccountGet(int id)
        {
            return db.Accounts.FirstOrDefault(ba => ba.Id == id);
        }

        public IEnumerable<BO.BankAccount> BankAccountGetAll()
        {
            return db.Accounts;
        }

        public void BankAccountDelete(BO.BankAccount bankAccount)
        {
            db.Accounts.Remove(bankAccount);
        }
        #endregion

        #region BankAccountNotes
        public BO.BankAccountNote BankAccountNoteGet(int id)
        {
            return db.Notes.FirstOrDefault(n => n.Id == id);
        }

        public void BankAccountNoteDelete(BO.BankAccountNote note)
        {
            db.Notes.Remove(note);
        }
        #endregion

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
