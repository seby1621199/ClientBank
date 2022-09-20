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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for Trasnsfer.xaml
    /// </summary>
    public partial class Transfer : UserControl
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.global_user.Balance >= uint.Parse(input_amount.Text))
            {
                User user_transfer = new User(input_user.Text.ToString());
                user_transfer.Balance = user_transfer.Balance + uint.Parse(input_amount.Text);
                Globals.global_user.Balance = Globals.global_user.Balance - uint.Parse(input_amount.Text);
                Globals.global_user.Update();
                user_transfer.Update();
                result_text.Text = "Transfer successful!\nYour new balance is:  " + Globals.global_user.Balance;
            }
            else
            {
                result_text.Text = "Transfer failed!\nYour balance is:  " + Globals.global_user.Balance;
            }
        }
    }
}
