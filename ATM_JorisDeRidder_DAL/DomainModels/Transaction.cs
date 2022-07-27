﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    [Table("Transactions")]
    public class Transaction
    {
        public int TransactionID { get; set; }

        [Required]
        public int Amount { get; set; }

        public Account Account { get; set; }
        public ICollection<TransactionType> Transactiontypes { get; set; }
    }
}