using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class LoginViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());

        public string? foutmelding { get; set; }

        public ObservableCollection<Client> Clients { get; set; }

        public override string this[string columnName] => "";

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Register": OpenRegisterPage(); break;
                case "Login": OpenLogin(); break;
            }
        }

        public void OpenLogin()
        {
            Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen(x => x.ClientName));
        }

        private void OpenRegisterPage()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            View.RegisterView rview = new View.RegisterView();
            rview.DataContext = registerViewModel;
            rview.Show();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}