using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class AdminViewModel : BasisViewModel
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public Client Client { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient { get; set; }
        public string Foutmelding { get; set; }
        public override string this[string columnName] => "";

        public AdminViewModel()
        {
            Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen());
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
                case "Edit": ChangeClient(); break;
                case "Delete": RemoveClient(); break;
            }
        }

        private void RemoveClient()
        {
            if (this.IsGeldig())
            {
                unitOfWork.ClientRepo.Verwijderen(SelectedClient);
                unitOfWork.Save();
                Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen());
            }
            else
            {
                Foutmelding = Error;
            }
        }

        private void ChangeClient()
        {
            if (this.IsGeldig())
            {
                unitOfWork.ClientRepo.Aanpassen(SelectedClient);
                unitOfWork.Save();
                Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen());
            }
            else
            {
                Foutmelding = Error;
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