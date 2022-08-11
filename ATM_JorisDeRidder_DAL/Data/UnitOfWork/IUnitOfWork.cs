using ATM_JorisDeRidder_DAL.Data.Repositories;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> ClientRepo { get; }
        IRepository<Card> CardRepo { get; }
        IRepository<Account> AccountRepo { get; }
        IRepository<Balance> BalanceRepo { get; }
        IRepository<CardType> CardtypeRepo { get; }
        IRepository<Transaction> TransactionRepo { get; }
        IRepository<TransactionType> TransactiontypeRepo { get; }
        IRepository<CardAccount> CardAccountRepo { get; }

        int Save();
    }
}