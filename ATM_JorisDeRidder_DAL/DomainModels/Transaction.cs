using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}