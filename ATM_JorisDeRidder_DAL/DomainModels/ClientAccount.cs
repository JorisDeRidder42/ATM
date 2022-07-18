using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class ClientAccount
    {
        [Key]
        public int ClientAccountID { get; set; }

        [Index("IX_ClientIDAccountID", 1, IsUnique = true)]
        public int ClientID { get; set; }

        [Index("IX_ClientIDAccountID", 2, IsUnique = true)]
        public int AccountID { get; set; }

        public Client Client { get; set; }
        public Account Account { get; set; }
    }
}