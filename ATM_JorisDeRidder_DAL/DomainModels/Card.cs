using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardPassword { get; set; }

        public int FailedLogin { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}