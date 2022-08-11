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
    [Table("CardAccounts")]
    public class CardAccount : Basisklasse
    {
        public int CardAccountID { get; set; }
        public int CardID { get; set; }
        public int AccountID { get; set; }
        public Card Card { get; set; }
        public Account Account { get; set; }
    }
}