using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    [Table("Logs")]
    public class Log
    {
        public int LogID { get; set; }
        public int CardID { get; set; }

        public string DateLog { get; set; }

        public Card Card { get; set; }
    }
}