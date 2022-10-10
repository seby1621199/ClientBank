using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BankClient.Pagess
{
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
            user_balance.Text = "Balance: " + Globals.global_user.Balance.ToString();
            user_iban.Text = "IBAN: " + Globals.global_user.IBAN;
            card_cvv.Text = "CVV: " + Globals.global_user.Cardul.CVV;
            card_number.Text = "Number: " + Globals.global_user.Cardul.Number;
            card_expiration.Text = "Expiration: " + Globals.global_user.Cardul.Expiration;
            card_type.Text = "Type: " + Globals.global_user.Cardul.GetType().Name;
        }

        private void Clipboard_Data(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var text = (sender as TextBlock).Text;
            if (text == null)
            {
                return;
            }
            else
            {
                Clipboard.SetText(text.Split(' ').Skip(1).FirstOrDefault()); ;
            }
            
        }

        private void Info_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var text = (TextBlock) sender;
            text.Opacity = 0.5;


        }

        private void Info_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var text = (TextBlock)sender;
            text.Opacity = 1;

        }
    }
}
