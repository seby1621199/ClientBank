using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankClient.Pagess { 
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            user_welcome_message.Text = "Welcome " + Globals.global_user.Username;
            user_name.Text = Globals.global_user.First_Name + " " + Globals.global_user.Last_Name;
            user_balance.Text = "Balance: "+Globals.global_user.Balance.ToString();
            user_iban.Text = "IBAN: " + Globals.global_user.IBAN;
            card_cvv.Text = "CVV: " + Globals.global_user.Card.CVV;
            card_number.Text = "Number: " + Globals.global_user.Card.Number;
            card_expiration.Text = "Expiration: " + Globals.global_user.Card.Expiration;


        }
    }
}
