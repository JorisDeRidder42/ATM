using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.Data
{
    public class ATM_JorisDeRidderEntities : DbContext
    {
        public ATM_JorisDeRidderEntities() : base("name=ATM_JorisDeRidderConnectionString")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }
    }
}