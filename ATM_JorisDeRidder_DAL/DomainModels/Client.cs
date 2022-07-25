using JullieZijnGeslaagd_DAL.BasisModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class Client : Basisklasse
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsIngelogd { get; set; }
        public DateTimeOffset BirthDate { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public ICollection<ClientAccount> ClientAccounts { get; set; }
    }
}