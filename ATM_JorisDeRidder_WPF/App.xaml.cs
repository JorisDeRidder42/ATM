using ATM_JorisDeRidder_WPF.ViewModel;
using ATM_JorisDeRidder_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_JorisDeRidder_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            HomeViewModel HviewModel = new HomeViewModel();
            View.HomeView hview = new View.HomeView();
            hview.DataContext = HviewModel;
            hview.Show();
        }
    }
}