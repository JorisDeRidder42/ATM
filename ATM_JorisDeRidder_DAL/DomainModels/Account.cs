using JullieZijnGeslaagd_DAL.BasisModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class Account : Basisklasse
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        public string Name { get; set; }

        public string type { get; set; }

        public ICollection<ClientAccount> ClientAccounts { get; set; }

        public int TransactionID { get; set; }
        public Transaction Transaction { get; set; }
    }
}