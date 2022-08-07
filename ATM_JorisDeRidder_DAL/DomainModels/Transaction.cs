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
    [Table("Transactions")]
    public class Transaction : Basisklasse
    {
        public int TransactionID { get; set; }
        public TransactionType TransactionTypeID { get; set; }

        [Required]
        public int TransactionAmount { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}