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
    public class Account : Basisklasse
    {
        public int AccountID { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public int AccountAmount { get; set; }

        public int BalanceID { get; set; }
        public int TransactionID { get; set; }
        public int ClientID { get; set; }

        public Client Client { get; set; }
        public Balance Balance { get; set; }
        public Transaction Transaction { get; set; }
        public ICollection<CardAccount> CardAccounts { get; set; }

        //.select -> terug navigeren naar ...
    }
}