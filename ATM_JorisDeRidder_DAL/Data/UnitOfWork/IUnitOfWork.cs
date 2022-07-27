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
        IRepository<Log> LogRepo { get; }
        IRepository<Transaction> TransactionRepo { get; }
        IRepository<TransactionType> TransactiontypeRepo { get; }
        IRepository<ClientAccount> ClientAccountRepo { get; }

        int Save();
    }
}