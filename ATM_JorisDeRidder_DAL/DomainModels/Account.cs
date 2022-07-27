using JullieZijnGeslaagd_DAL.BasisModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    [Table("Accounts")]
    public class Account
    {
        public int AccountID { get; set; }

        [Required]
        public string AccountName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<ClientAccount> ClientAccounts { get; set; }
        public Card Card { get; set; }
    }
}