﻿using System;
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
            //user_balance.Text = "Balance: " + Globals.global_user.Balance.ToString();
           // user_iban.Text = "IBAN: " + Globals.global_user.IBAN;
            card_cvv.Text = "CVV: " + Globals.global_user.Cardul.CVV;
            card_number.Text = "Number: " + Globals.global_user.Cardul.Number;
            card_expiration.Text = "Expiration: " + Globals.global_user.Cardul.Expiration;
            card_type.Text = "Type: " + Globals.global_user.Cardul.GetType().Name;
            user_balance.Text = "Balance: " + Math.Round(Globals.global_user.Accounts[0].Balance, 2).ToString();
            user_iban.Text = "IBAN: " + Globals.global_user.Accounts[0].IBAN;
            account_currency.Text = "Currency: " + Globals.global_user.Accounts[0].Currency;
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
            int nr = -1;
            for (int i = 0; i < Globals.global_user.Accounts.Count; i++)
            {
                if (Globals.global_user.Accounts[i].IBAN == (string)Account_Select.SelectedValue)
                {
                    nr = i;
                }

            }
            user_balance.Text = "Balance: " + Math.Round(Globals.global_user.Accounts[nr].Balance, 2).ToString();
            user_iban.Text = "IBAN: " + Globals.global_user.Accounts[nr].IBAN;
            account_currency.Text = "Currency: " + Globals.global_user.Accounts[nr].Currency;


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
            var text = (TextBlock)sender;
            text.Opacity = 0.5;


        }

        private void Info_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var text = (TextBlock)sender;
            text.Opacity = 1;

        }
    }
}
