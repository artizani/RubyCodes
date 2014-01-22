using System;
using NVoucher.Model;

namespace NVoucher.Data
{

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Balance> balanceRepository;
        private GenericRepository<Profile> profileRepository;
        private GenericRepository<Credit> creditRepository;
        private GenericRepository<Debit> debitRepository;
        private GenericRepository<Transaction> transactionRepository;
    

        public GenericRepository<Balance> BalanceRepository
        {
            get
            {

                if (this.balanceRepository == null)
                {
                    this.balanceRepository = new GenericRepository<Balance>(context);
                }
                return balanceRepository;
            }
        }

          public GenericRepository<Credit> CreditRepository
        {
            get
            {

                if (this.creditRepository == null)
                {
                    this.creditRepository = new GenericRepository<Credit>(context);
                }
                return creditRepository;
            }
        }

          public GenericRepository<Debit> DebitRepository
        {
            get
            {

                if (this.creditRepository == null)
                {
                    this.debitRepository = new GenericRepository<Debit>(context);
                }
                return debitRepository;
            }
        }


          public GenericRepository<Transaction> TransactionRepository
        {
            get
            {

                if (this.transactionRepository == null)
                {
                    this.transactionRepository = new GenericRepository<Transaction>(context);
                }
                return transactionRepository;
            }
        }


          public GenericRepository<Profile> ProfileRepository
        {
            get
            {

                if (this.profileRepository == null)
                {
                    this.profileRepository = new GenericRepository<Profile>(context);
                }
                return profileRepository;
            }
        }
   

        public void Save()
        {
            context.SaveChanges();
        }

        public void SaveAsync()
        {
            context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
