using BankClient.Classes;
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
            ///de editat asta 
            sold.Text = "Sold: " + Globals.global_user.Accounts[0].Balance.ToString()+" RON";
            LoadAccounts();

        }

        private void LoadAccounts()
        {
            {
                foreach (var account in Globals.global_user.Accounts)
                {
                    this.Account_Select.Items.Add(account.IBAN);
                }
            }
        }

        private void Btn_deposit_Click(object sender, RoutedEventArgs e)
        {

            if (Account_Select.SelectedItem == null)
                result_text.Text = " Please select your Account!";
            else
            {

                //  Globals.global_user.Balance += uint.Parse(input_amount.Text);
                //Globals.global_user.Update();
                int nr = Globals.global_user.Deposit(uint.Parse(input_amount.Text), Account_Select.Text);
                result_text.Text = "Deposit successful!\nYour new balance is: " + Globals.global_user.Accounts[nr].Balance.ToString() + " in account " + Account_Select.Text;
                sold.Text = "Sold: " + Globals.global_user.Accounts[nr].Balance.ToString() + " " + Globals.global_user.Accounts[nr].Currency;
            }



        }

        private void Account_Select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int nr = -1;
            for (int i = 0; i < Globals.global_user.Accounts.Count; i++)
            {
                if (Globals.global_user.Accounts[i].IBAN == (string)Account_Select.SelectedValue)
                {
                    nr = i;
                }
               
            }
            sold.Text = "Sold: " + Globals.global_user.Accounts[nr].Balance.ToString() + " " + Globals.global_user.Accounts[nr].Currency;

        }
    }
}
