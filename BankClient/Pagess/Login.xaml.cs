using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;




namespace BankClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {

            InitializeComponent();
            DB();
            register_final.Visibility = Visibility.Hidden;
        }
        public void DB()
        {
            Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
            Globals.m_Database = Globals.m_Client.GetDatabase("bank");
            Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");
        }



        private void Button_Click(object sender, RoutedEventArgs e)
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

            if (search != null)

                if (search.Password == user.Password)
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Content = "Login succesful.";
                    Globals.global_user = search;
                    UserMenu userMenu = new UserMenu();
                    userMenu.Show();
                    this.Close();

                }
                else
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Content = "Wrong password.";
                }
            else
            {
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Content = "User dont exist.";
                }
            }


        }


        private void Register_button_Click(object sender, RoutedEventArgs e)
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

            if (search == null)
            {
                if (Encryption.Decrypt(user.Password).Length < 6)
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Content = "Password must contain at least 6 characters.";
                }
                else
                {
                    result_text.Visibility = Visibility.Visible;
                    result_text.Content = "Register succesful.";
                    Globals.m_Collection.InsertOne(user);
                    Globals.global_user = user;
                    Final_step_register();
                }
            }
            else
            {
                result_text.Visibility = Visibility.Visible;
                result_text.Content = "User already exist.";

            }

        }

        private void Final_step_register()
        {
            this.Width = 640;
            register_final.Visibility = Visibility.Visible;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void test_btn_Click(object sender, RoutedEventArgs e)
        {
            Pagess.MenuClient menuClient = new Pagess.MenuClient();
            menuClient.Show();

        }

        private void button_finish_register_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            Globals.global_user.First_Name = first_name_input.Text.ToUpper();
            Globals.global_user.Last_Name = last_name_input.Text.ToUpper();
            Globals.global_user.Country = country_input.Text.ToUpper();
            Globals.global_user.IBAN = Globals.global_user.Country[0].ToString() + Globals.global_user.Country[1].ToString() + rnd.Next(10, 99) + "BNK" + Globals.global_user.First_Name[0].ToString() + Globals.global_user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);
            Globals.global_user.Update();
            register_final.Visibility = Visibility.Hidden;
            this.Width = 320;

        }
    }
}
