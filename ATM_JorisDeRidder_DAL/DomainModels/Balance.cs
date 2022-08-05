using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    [Table("Balances")]
    public class Balance
    {
        public int BalanceID { get; set; }
        public int BalanceAmount { get; set; }

        public ICollection<Account> accounts { get; set; }
    }
}