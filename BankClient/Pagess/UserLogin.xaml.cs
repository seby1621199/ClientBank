using MongoDB.Driver;
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
using System.Windows.Shapes;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
            DB();

        }
        public void DB()
        {
            Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
            Globals.m_Database = Globals.m_Client.GetDatabase("bank");
            Globals.m_Collection = Globals.m_Database.GetCollection<User>("users");
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
       
                    RegisterUser registerUser = new RegisterUser();
                    registerUser.Show();
           
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {

            User user = new User
            {
                Username = user_input.Text,
                Balance = 0,
                Password = Encryption.Encrypt(password_input.Password.ToString())
            };
            ;

            var filter = Builders<User>.Filter.Eq("Username", user.Username);
            User search = Globals.m_Collection.Find(filter).FirstOrDefault();
            if (user_input.Text == "" || password_input.Password == "" )
            { 
                result_text.Text = "Please fill in all the fields.";

            }
        else
            if (search != null)

                if (search.Password == user.Password)
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Text = "Login succesful.";
                    Globals.global_user = search;
                    
                    MenuUser menuUser = new MenuUser();
                    menuUser.Show();
                    this.Close();

                }
                else
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Text = "Wrong password.";
                }
            else
            {
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Text = "User dont exist.";
                }
            }
        }

        private void user_input_Error(object sender, ValidationErrorEventArgs e)
        {
            result_text.Visibility = Visibility.Visible;
            result_text.Text = "User dont exist.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuUser menuUser = new MenuUser();
            menuUser.Show();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btn_close_MouseEnter(object sender, MouseEventArgs e)
        {
            icon_exit.Foreground = Brushes.IndianRed;

        }

        private void btn_close_MouseLeave(object sender, MouseEventArgs e)
        {
            icon_exit.Foreground = new SolidColorBrush(Color.FromRgb(221, 255, 255));

        }
    }
}
