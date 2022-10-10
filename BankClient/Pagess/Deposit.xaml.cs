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
            sold.Text = "Sold: " + Globals.global_user.Balance.ToString();
        }


        private void Btn_deposit_Click(object sender, RoutedEventArgs e)
        {


          //  Globals.global_user.Balance += uint.Parse(input_amount.Text);
            //Globals.global_user.Update();
            Globals.global_user.Deposit(uint.Parse(input_amount.Text));
            result_text.Text = "Deposit successful!\nYour new balance is:  " + Globals.global_user.Balance;
            sold.Text = "Sold: " + Globals.global_user.Balance.ToString();




        }
    }
}
