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
    public class Card
    {
        public int CardID { get; set; }
        public string CardName { get; set; }
        public int LogID { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; }
        public Log Log { get; set; }
    }
}