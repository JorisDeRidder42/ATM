using ATM_JorisDeRidder_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.DomainModels
{
    public class DataManager
    {
        public static int ClientsToevoegen(Client client)
        {
            using (ATM_JorisDeRidderEntities atm_JorisDeRidderEntities = new ATM_JorisDeRidderEntities())
            {
                atm_JorisDeRidderEntities.Clients.Add(client);
                return atm_JorisDeRidderEntities.SaveChanges();
            }
        }
    }
}