using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class AdminViewModel : BasisViewModel
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public Client Client { get; set; }
        public override string this[string columnName] => "";

        private Client selectedClient;

        public Client SelectedReeks
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
            }
        }

        public AdminViewModel(int clientID)
        {
            Client = unitOfWork.ClientRepo.Ophalen(c => c.ClientID == clientID).SingleOrDefault();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Back": Back(); break;
            }
        }

        private void Back()
        {
            LoginViewModel lviewModel = new LoginViewModel();
            View.LoginView lView = new View.LoginView();
            lView.DataContext = lviewModel;
            lView.Show();
        }
    }
}