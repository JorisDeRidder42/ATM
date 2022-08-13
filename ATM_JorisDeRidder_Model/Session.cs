using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_JorisDeRidder_Model
{
    public static class Session
    {
        public static int SelectedItemId;
        public static int SelectedAccountId;
        public static int SelectedTransactionId;

        public static Window window;

        public static void ClosePreviousWindow(Window view)
        {
            if (window != null)
            {
                window.Close();
            }
            window = view;
        }
    }
}