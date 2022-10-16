using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : UserControl
    {
        public Withdraw()
        {
            InitializeComponent();
            sold.Text = "Sold: " + Globals.global_user.Accounts[0].Balance.ToString() + " RON";
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

        private void Account_Select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //change sold.Text to the selected account from the list
            int nr = -1;
            for (int i = 0; i < Globals.global_user.Accounts.Count; i++)
            {
                if (Globals.global_user.Accounts[i].IBAN == (string)Account_Select.SelectedValue)
                {
                    nr = i;
                }
                
            }
            sold.Text = "Sold: " + Math.Round(Globals.global_user.Accounts[nr].Balance, 2).ToString() + " " + Globals.global_user.Accounts[nr].Currency;

        }



        private void Btn_withdraw_Click(object sender, RoutedEventArgs e)
        {
            int nr = Globals.global_user.GetAccountNumber(Account_Select.Text);
            result_text.Foreground = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            if (Account_Select.SelectedItem == null)
                result_text.Text = " Please select your Account!";
            else
            {
                if (Globals.global_user.Accounts[nr].Balance >= Convert.ToDouble(input_amount.Text))
                {
                    Globals.global_user.WithDraw(Convert.ToDouble(input_amount.Text), Account_Select.Text);
                    result_text.Text = "Withdraw successful!\nYour new balance is: " + Globals.global_user.Accounts[nr].Balance.ToString() + " in account " + Account_Select.Text;
                    sold.Text = "Sold: " + Globals.global_user.Accounts[nr].Balance.ToString() + " " + Globals.global_user.Accounts[nr].Currency;
                }
                else
                {
                    result_text.Foreground = Brushes.OrangeRed;
                    result_text.Text = "Withdraw failed!\nYour balance is:  " + Globals.global_user.Accounts[nr].Balance;
                }
            }
        }
    }
}
