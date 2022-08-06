using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    [Table("TransactionTypes")]
    public class TransactionType
    {
        public int TransActionTypeID { get; set; }

        [Required]
        public string TransactionTypeName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}