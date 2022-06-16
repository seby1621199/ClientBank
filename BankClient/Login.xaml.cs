using System.Linq;
using System.Windows;
using System.Windows.Input;
using MongoDB.Driver;




namespace BankClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private void DB()
        {
            Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
            Globals.m_Database = Globals.m_Client.GetDatabase("bank");
            Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* Conectarea la  */
            DB();
            /* */
            User user = new User
            {
                Username = user_input.Text,
                Balance = 0,
                Password = Encryption.Encrypt(password_input.Text)
            };
            ;
            //Globals.m_Collection.InsertOne(user);
            //var password = Encryption.Encrypt(password_input.Text);
            var filter = Builders<User>.Filter.Eq("Username", user.Username);
            User search = Globals.m_Collection.Find(filter).FirstOrDefault();
            //    result_text.Visibility = Visibility.Visible;
            //   result_text.Content = "User " + user.username + " already exist!";


            //if (search!=null)
            //{
            //    result_text.Visibility = Visibility.Visible;
            //    result_text.Content = "User "+search.password+" already exist!";
            //}
            if (search != null)

                    if (search.Password == user.Password)
                    {
                        result_text.Visibility = Visibility.Visible;
                        result_text.Content = "Login succesful.";
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

        private void final_step_register(&User user)
        {
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void Register_button_Click(object sender, RoutedEventArgs e)
        {
            /* Conectarea la  */
            DB();
            /* */
            User user = new User
            {
                Username = user_input.Text,
                Balance = 0,
                Password = Encryption.Encrypt(password_input.Text)
            };
            ;

            var filter = Builders<User>.Filter.Eq("Username", user.Username);
            User search = Globals.m_Collection.Find(filter).FirstOrDefault();

            if (search == null)
            {
                result_text.Visibility = Visibility.Visible;
                result_text.Content = "Register succesful.";
                Globals.m_Collection.InsertOne(user);
            }
            else
            {
                result_text.Visibility = Visibility.Visible;
                result_text.Content = "User already exist.";

            }

        }
    }
}
