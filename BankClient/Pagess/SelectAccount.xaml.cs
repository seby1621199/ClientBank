using BankClient.Classes;
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

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for SelectCard.xaml
    /// </summary>
    public partial class SelectAccount : UserControl
    {
        public SelectAccount()
        {
            InitializeComponent();
        }

        private void Select_Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Random rnd = new Random();
            //info_account.Visibility = Visibility.Visible;
            ////generate ibon
            //string IBAN = ((ComboBoxItem)Select_Currency.SelectedValue).Content.ToString() + "897" + rnd.Next(10, 99) + "BNK" + Globals.global_user.First_Name[0].ToString() + Globals.global_user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);
            //IBAN = IBAN.ToUpper();
            //Account account = new Account(((ComboBoxItem)Select_Currency.SelectedValue).Content.ToString(), 0,IBAN);
            //Globals.global_user.Accounts.Add(account);
            //Globals.global_user.Update();
            //result_text.Text = "Account created successfully!\nIBAN: " + IBAN;
            


        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            //user with cardul type classic can make only 2 accounts, siver 3, gold 4, platinum 5
            if (Globals.global_user.Cardul is Silver)
            {
                if (Globals.global_user.Accounts.Count >= 3)
                {
                    result_text.Text = "You can't create more accounts! Maxim 3 accounts!";
                    return;
                }
            }
            else if (Globals.global_user.Cardul is Classic)
            {
                if (Globals.global_user.Accounts.Count >= 2)
                {
                    result_text.Text = "You can't create more accounts! Maxim 2 accounts!";
                    return;
                }
            }
            else if (Globals.global_user.Cardul is Gold)
            {
                if (Globals.global_user.Accounts.Count >= 4)
                {
                    result_text.Text = "You can't create more accounts! Maxim 4 accounts!";
                    return;
                }
            }
            else if (Globals.global_user.Cardul is Platinum)
            {
                if (Globals.global_user.Accounts.Count >= 5)
                {
                    result_text.Text = "You can't create more accounts! Maxim 5 accounts!";
                    return;
                }
                else
                {
                    Random rnd = new Random();
                    info_account.Visibility = Visibility.Visible;
                    string IBAN = ((ComboBoxItem)Select_Currency.SelectedValue).Content.ToString() + "897" + rnd.Next(10, 99) + "BNK" + Globals.global_user.First_Name[0].ToString() + Globals.global_user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);
                    IBAN = IBAN.ToUpper();
                    Account account = new Account(((ComboBoxItem)Select_Currency.SelectedValue).Content.ToString(), 0, IBAN);
                    Globals.global_user.Accounts.Add(account);
                    Globals.global_user.Update();
                    account_currency.Text = "Currency: " + account.Currency;
                    user_name.Text = Globals.global_user.First_Name + " " + Globals.global_user.Last_Name;
                    user_iban.Text = "IBAN: " + account.IBAN;

                    result_text.Text = "Account created successfully!\nIBAN: " + IBAN;
                }
            }

            //Random rnd = new Random();
            //info_account.Visibility = Visibility.Visible;
            //string IBAN = ((ComboBoxItem)Select_Currency.SelectedValue).Content.ToString() + "897" + rnd.Next(10, 99) + "BNK" + Globals.global_user.First_Name[0].ToString() + Globals.global_user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);
            //IBAN = IBAN.ToUpper();
            //Account account = new Account(((ComboBoxItem)Select_Currency.SelectedValue).Content.ToString(), 0, IBAN);
            //Globals.global_user.Accounts.Add(account);
            //Globals.global_user.Update();
            //account_currency.Text = "Currency: "+account.Currency;
            //user_name.Text = Globals.global_user.First_Name + " " + Globals.global_user.Last_Name;
            //user_iban.Text = "IBAN: "+account.IBAN;

            //result_text.Text = "Account created successfully!\nIBAN: " + IBAN;

        }
    }
}
