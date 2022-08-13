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
        private IRepository<Transaction> _transactionRepo;
        private IRepository<CardType> _cardtypeRepo;
        private IRepository<TransactionType> _transactiontypeRepo;
        private IRepository<CardAccount> _cardAccountRepo;

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

        public IRepository<CardAccount> CardAccountRepo
        {
            get
            {
                if (_cardAccountRepo == null)
                {
                    _cardAccountRepo = new Repository<CardAccount>(this.ATM_JorisDeRidderEntities);
                }
                return _cardAccountRepo;
            }
        }

        public IRepository<CardType> CardtypeRepo
        {
            get
            {
                if (_cardtypeRepo == null)
                {
                    _cardtypeRepo = new Repository<CardType>(this.ATM_JorisDeRidderEntities);
                }
                return _cardtypeRepo;
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

        public IRepository<TransactionType> TransactiontypeRepo
        {
            get
            {
                if (_transactiontypeRepo == null)
                {
                    _transactiontypeRepo = new Repository<TransactionType>(this.ATM_JorisDeRidderEntities);
                }
                return _transactiontypeRepo;
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