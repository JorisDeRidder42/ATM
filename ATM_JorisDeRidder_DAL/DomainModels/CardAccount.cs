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
        [Key]
        public int CardAccountID { get; set; }

        [Index("IX_CardIDAccountID", 1, IsUnique = true)]
        public int CardID { get; set; }

        [Index("IX_CardIDAccountID", 2, IsUnique = true)]
        public int AccountID { get; set; }

        [ForeignKey("CardID")]
        public Card Card { get; set; }

        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}