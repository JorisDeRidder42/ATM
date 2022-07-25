using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class Log
    {
        [Key]
        public int LogID { get; set; }

        [Required]
        public int Total_Amount { get; set; }

        [Required]
        public DateTime dateLog { get; set; }

        public Card Card { get; set; }
    }
}