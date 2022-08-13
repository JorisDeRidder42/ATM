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
    [Table("Cards")]
    public class Card : Basisklasse
    {
        [Key]
        public int CardID { get; set; }

        [Required]
        public string CardName { get; set; }

        [Required]
        public int CardTypeID { get; set; }

        [ForeignKey("CardTypeID")]
        public CardType CardType { get; set; }

        public ICollection<CardAccount> CardAccounts { get; set; }
    }
}