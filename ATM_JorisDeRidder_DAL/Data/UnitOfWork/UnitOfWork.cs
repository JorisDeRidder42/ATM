using ATM_JorisDeRidder_DAL.Data.Repositories;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Client> _clientRepo;
        private IRepository<Account> _accountRepo;
        private IRepository<Card> _cardRepo;
        private IRepository<Log> _logRepo;
        private IRepository<Transaction> _transactionRepo;
        private IRepository<ClientAccount> _clientAccountRepo;
        public IRepository<Log> LogRepo => throw new NotImplementedException();

        public UnitOfWork(ATM_JorisDeRidderEntities atm_JorisDeRidderEntities)
        {
            this.ATM_JorisDeRidderEntities = atm_JorisDeRidderEntities;
        }

        private ATM_JorisDeRidderEntities ATM_JorisDeRidderEntities { get; }

        public IRepository<Account> AccountRepo
        {
            get
            {
                if (_accountRepo == null)
                {
                    _accountRepo = new Repository<Account>(this.ATM_JorisDeRidderEntities);
                }
                return _accountRepo;
            }
        }

        public IRepository<Card> CardRepo
        {
            get
            {
                if (_cardRepo == null)
                {
                    _cardRepo = new Repository<Card>(this.ATM_JorisDeRidderEntities);
                }
                return _cardRepo;
            }
        }

        public IRepository<Client> ClientRepo
        {
            get
            {
                if (_clientRepo == null)
                {
                    _clientRepo = new Repository<Client>(this.ATM_JorisDeRidderEntities);
                }
                return _clientRepo;
            }
        }

        public IRepository<ClientAccount> ClientAccountRepo
        {
            get
            {
                if (_clientAccountRepo == null)
                {
                    _clientAccountRepo = new Repository<ClientAccount>(this.ATM_JorisDeRidderEntities);
                }
                return _clientAccountRepo;
            }
        }

        public IRepository<Log> LogsRepo
        {
            get
            {
                if (_logRepo == null)
                {
                    _logRepo = new Repository<Log>(this.ATM_JorisDeRidderEntities);
                }
                return _logRepo;
            }
        }

        public IRepository<Transaction> TransactionRepo
        {
            get
            {
                if (_transactionRepo == null)
                {
                    _transactionRepo = new Repository<Transaction>(this.ATM_JorisDeRidderEntities);
                }
                return _transactionRepo;
            }
        }

        public void Dispose()
        {
            ATM_JorisDeRidderEntities.Dispose();
        }

        public int Save()
        {
            return ATM_JorisDeRidderEntities.SaveChanges();
        }
    }
}