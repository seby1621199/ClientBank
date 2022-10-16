using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for Trasnsfer.xaml
    /// </summary>
    public partial class Transfer : UserControl
    {
        int nr_cont_from = -1;
        User beneficiary = new User();
        string beneficiary_account = "";
        public Transfer()
        {
            InitializeComponent();
            curs_valuar.Visibility = Visibility.Hidden;
            curs_text.Visibility = Visibility.Hidden;
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

        private void Btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.global_user.Accounts[nr_cont_from].Balance >= Convert.ToDouble(input_amount.Text))
            {
                _ = Globals.global_user.TransferAsync(nr_cont_from, beneficiary_account, Convert.ToDouble(input_amount.Text));
                result_text.Text = "Transfer successful! Your new balance is:  " + Math.Round(Globals.global_user.Accounts[nr_cont_from].Balance, 2);
            }
            else
            {
                result_text.Text = "Transfer failed! Your balance is:  " + Math.Round(Globals.global_user.Accounts[nr_cont_from].Balance, 2);
            }
        }




        private void Input_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter_username = Builders<User>.Filter.Eq("Username", input_user.Text.ToString());

            var filter_iban = Builders<User>.Filter.ElemMatch(x => x.Accounts, x => x.IBAN == input_user.Text.ToString());
            List<User> users_username = Globals.m_Collection.Find(filter_username).ToList();

            List<User> users_iban = Globals.m_Collection.Find(filter_iban).ToList();
            List<User> users;
            users = users_username;
            users = users.Concat(users_iban).ToList();
            users = users.Distinct().ToList();

            TextBlock new_users = new TextBlock();

            if (users.Count == 0)
            {
                result_text.Text = "User does not exist!";
                users_area.Visibility = Visibility.Collapsed;
                users_area.Children.Clear();
            }
            else
            {
                result_text.Text = "Found:\n";
                if (input_user.Text == "")
                    result_text.Text = "";

                for (int i = 0; i < users.Count; i++)
                {
                    users_area.Visibility = Visibility.Visible;
                    TextBlock to_add = new TextBlock
                    {
                        Foreground = new SolidColorBrush(Color.FromRgb(245, 245, 245)),
                        FontSize = 14,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Padding = new Thickness(0, 10, 0, 10),
                        HorizontalAlignment = HorizontalAlignment.Left

                    }; //de modificat aici 
                    to_add.MouseLeftButtonDown += To_add_MouseLeftButtonDown;
                    to_add.MouseEnter += To_add_MouseEnter;
                    to_add.MouseLeave += To_add_MouseLeave;
                    //check if input_user is user ok account
                    if (users[i].Accounts.Any(x => x.IBAN == input_user.Text.ToString()))
                    {
                        to_add.Text = users[i].Username + " - " + input_user.Text.ToString();
                        to_add.Tag = input_user.Text.ToString();
                    }
                    else
                    {
                        to_add.Text = users[i].Username;
                        to_add.Tag = users[i].Accounts[0].IBAN;
                    }

                    //to_add.Text = users[i].Username;
                    to_add.Margin = new Thickness(10, 0, 10, 0);
                    to_add.Padding = new Thickness(10, 6, 10, 6);
                    to_add.Height = Double.NaN;
                    users_area.Children.Add(to_add);
                }
            }

        }

        private void To_add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var t = (TextBlock)sender;
            t.Background = btn_transfer.Background;
            t.Foreground = Brushes.White;
            //t.FontWeight = FontWeights.Bold;
            
            //t.Width = Double.NaN;
            //t.Padding = new Thickness(10, 0, 10, 0);
            beneficiary_account = (string)t.Tag;

            result_text.Text = "You have selected as beneficiary of the transfer account: " + beneficiary_account;
            if ((string)Account_Select.SelectedValue != "")
            {
                Update_Curs(Globals.global_user.Accounts[nr_cont_from].Currency, beneficiary_account.Substring(0, 3));
            }

        }

        private void To_add_MouseLeave(object sender, MouseEventArgs e)
        {
            var a = (TextBlock)sender;
            a.Opacity = 1;
        }

        private void To_add_MouseEnter(object sender, MouseEventArgs e)
        {
            var a = (TextBlock)sender;
            a.Opacity = 0.6;
        }

        private void Account_Select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nr_cont_from = -1;
            for (int i = 0; i < Globals.global_user.Accounts.Count; i++)
            {
                if (Globals.global_user.Accounts[i].IBAN == (string)Account_Select.SelectedValue)
                {
                    nr_cont_from = i;
                }

            }
            if (beneficiary_account != "")
            {
                Update_Curs(Globals.global_user.Accounts[nr_cont_from].Currency, beneficiary_account.Substring(0, 3));


            }






        }
        private async void Update_Curs(string from, string to)
        {
            if (from == to)
            {
                curs_valuar.Visibility = Visibility.Hidden;
                curs_text.Visibility = Visibility.Hidden;

            }
            else
            {
                curs_valuar.Visibility = Visibility.Visible;
                curs_text.Visibility = Visibility.Visible;
                double curs = await Globals.Convert(from, to, 1);
                curs = Math.Round(curs, 2);
                curs_valuar.Text = "1 " + from + "=" + curs.ToString() + " " + to;
                //curs_valuar.Text = await Globals.Convert(from, to, 1).ToString();
            }

        }
    }
}
