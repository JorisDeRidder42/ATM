﻿using JullieZijnGeslaagd_DAL.BasisModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    [Table("CardTypes")]
    public class CardType : Basisklasse
    {
        [Key]
        public int CardTypeID { get; set; }

        [Required]
        public string CardTypeName { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}