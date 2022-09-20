using System.Windows;
using System.Windows.Controls;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for Deposit.xaml
    /// </summary>
    public partial class Deposit : UserControl
    {
        public Deposit()
        {
            InitializeComponent();
        }


        private void btn_deposit_Click(object sender, RoutedEventArgs e)
        {


            Globals.global_user.Balance = Globals.global_user.Balance + uint.Parse(input_amount.Text);
            Globals.global_user.Update();
            result_text.Text = "Deposit successful!\nYour new balance is:  " + Globals.global_user.Balance;




        }
    }
}
