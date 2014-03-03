using System;
using NVoucher.Model;

namespace NVoucher.Data
{
    public interface IUnitOfWork
    {
        IRepository<Balance> BalanceRepository { get; }
        IRepository<Credit> CreditRepository { get; }
        IRepository<Debit> DebitRepository { get; }
        IRepository<Transaction> TransactionRepository { get; }
        IRepository<Profile> ProfileRepository { get; }
        void Save();
        void SaveAsync();
        void Dispose();
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private IRepository<Balance> _balanceRepository;
        private IRepository<Profile> _profileRepository;
        private IRepository<Credit> _creditRepository;
        private IRepository<Debit> _debitRepository;
        private IRepository<Transaction> _transactionRepository;
    

        public IRepository<Balance> BalanceRepository
        {
            get {
                return this._balanceRepository ??
                       (this._balanceRepository = new GenericRepository<Balance>(this.context));
            }
        }

        public IRepository<Credit> CreditRepository
        {
            get {
                return this._creditRepository ?? (this._creditRepository = new GenericRepository<Credit>(this.context));
            }
        }

        public IRepository<Debit> DebitRepository
        {
            get {
                return this._debitRepository ?? (this._debitRepository = new GenericRepository<Debit>(this.context));
            }
        }


        public IRepository<Transaction> TransactionRepository
        {
            get {
                return this._transactionRepository ??
                       (this._transactionRepository = new GenericRepository<Transaction>(this.context));
            }
        }


        public IRepository<Profile> ProfileRepository
        {
            get {
                return this._profileRepository ??
                       (this._profileRepository = new GenericRepository<Profile>(this.context));
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
