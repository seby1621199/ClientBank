using BankClient.Classes;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {
        public RegisterUser()
        {
            InitializeComponent();
        }


        private void Button_register_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            User user = new User
            {
                Balance = 0,
                Username = input_username.Text,
                Password = Encryption.Encrypt(input_password.Password.ToString()),
                First_Name = input_firstName.Text,
                Last_Name = input_lastName.Text,
                Country = input_country.Text
            };



            var filter = Builders<User>.Filter.Eq("Username", user.Username);
            User search = Globals.m_Collection.Find(filter).FirstOrDefault();
            if (input_username.Text == "" || input_password.Password == "" || input_firstName.Text == "" || input_lastName.Text == "" || input_country.Text == "")
            {
                result_text.Text = "Please fill in all the fields.";

            }
            else
            if (search == null)
            {
                if (Encryption.Decrypt(user.Password).Length < 6)
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Text = "Password must contain at least 6 characters.";
                }
                else
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Text = "Register succesful.";

                    Card card = new Card
                    {
                        Number = rnd.Next(100000000, 999999999).ToString(),
                        CVV = rnd.Next(100, 999).ToString(),
                        Expiration = DateTime.Now.ToString("MM/yy")
                    };

                    user.Card = card;


                    user.IBAN = user.Country[0].ToString() + user.Country[1].ToString() + rnd.Next(10, 99) + "BNK" + user.First_Name[0].ToString() + user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);
                    user.IBAN = user.IBAN.ToUpper();
                    Globals.m_Collection.InsertOne(user);
                    Globals.global_user = user;
                }
            }
            else
            {
                result_text.Visibility = Visibility.Visible;
                result_text.Text = "User already exist.";

            }

            this.Close();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Btn_back_MouseEnter(object sender, MouseEventArgs e)
        {
            back_icon.Opacity = 0.6;

        }

        private void Btn_back_MouseLeave(object sender, MouseEventArgs e)
        {
            back_icon.Opacity = 1;

        }
    }
}
