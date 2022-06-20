using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using MongoDB.Driver;

namespace BankClient
{
    /// <summary>
    /// Interaction logic for RegisterFinal.xaml
    /// </summary>
    public partial class RegisterFinal : Window
    {

        public RegisterFinal()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

#pragma warning disable IDE1006 // Naming Styles
        private void button_finish_register_Click(object sender, RoutedEventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            Random rnd = new Random();
            Globals.global_user.First_Name = first_name_input.Text.ToUpper();
            Globals.global_user.Last_Name = last_name_input.Text.ToUpper();
            Globals.global_user.Country = country_input.Text.ToUpper();
            Globals.global_user.IBAN = Globals.global_user.Country[0].ToString() + Globals.global_user.Country[1].ToString() + rnd.Next(10, 99) + "BNK" + Globals.global_user.First_Name[0].ToString() + Globals.global_user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);
            Globals.global_user.Update();

            // User search = Globals.m_Collection.Find(filter).FirstOrDefault();
            register_final_txt.Visibility = Visibility.Visible;
            this.Close();



        }
    }

}
