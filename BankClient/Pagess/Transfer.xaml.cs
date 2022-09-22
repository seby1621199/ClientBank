using MongoDB.Driver;
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
        User beneficiary = new User();
        public Transfer()
        {
            InitializeComponent();
        }

        private void Btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.global_user.Balance >= uint.Parse(input_amount.Text))
            {
                User user_transfer = beneficiary;
                user_transfer.Balance += uint.Parse(input_amount.Text);
                Globals.global_user.Balance -= uint.Parse(input_amount.Text);
                Globals.global_user.Update();
                user_transfer.Update();
                result_text.Text = "Transfer successful!\nYour new balance is:  " + Globals.global_user.Balance;
            }
            else
            {
                result_text.Text = "Transfer failed!\nYour balance is:  " + Globals.global_user.Balance;
            }
        }




        private void Input_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            //create a search filter for the user collection based on the input text from the user textbox 
            var filter_username = Builders<User>.Filter.Eq("Username", input_user.Text.ToString());
            var filter_last_name = Builders<User>.Filter.Eq("Last_Name", input_user.Text.ToString());
            var filter_iban = Builders<User>.Filter.Eq("IBAN", input_user.Text.ToString());
            //create a list of users that match the filter
            List<User> users_username = Globals.m_Collection.Find(filter_username).ToList();
            List<User> users_lastname = Globals.m_Collection.Find(filter_last_name).ToList();
            List<User> users_iban = Globals.m_Collection.Find(filter_iban).ToList();
            List<User> users;
            //if the list is empty, the user does not exist
            //concatenate users_username and users_lastname in users
            users = users_username.Concat(users_lastname).ToList();
            users = users.Concat(users_iban).ToList();
            //remove dublicates of users by username 
            users = users.Distinct().ToList();


            // List<User> users = users_username.Join(users_lastname);


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
                    to_add.Tag = users[i];
                    to_add.MouseEnter += To_add_MouseEnter;
                    to_add.MouseLeave += To_add_MouseLeave;
                    to_add.Text = users[i].Username + " | IBAN: " + users[i].IBAN;
                    to_add.Margin = new Thickness(10, 0, 10, 0);
                    to_add.Padding = new Thickness(0, 10, 0, 10);
                    users_area.Children.Add(to_add);
                }
            }

        }

        private void To_add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  throw new NotImplementedException();
            var t = (TextBlock)sender;
            t.Background = Brushes.DarkGray;
            beneficiary = (User)t.Tag;

            result_text.Text = "You have selected as beneficiary of the transfer the user: " + beneficiary.Username;
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
    }
}
