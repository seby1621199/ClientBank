using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : UserControl
    {
        public Withdraw()
        {
            InitializeComponent();
            sold.Text = "Sold: " + Globals.global_user.Balance.ToString();
        }

        private void Btn_withdraw_Click(object sender, RoutedEventArgs e)
        {
            result_text.Foreground = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            if (Globals.global_user.Balance >= uint.Parse(input_amount.Text))
            {
                Globals.global_user.Balance -= uint.Parse(input_amount.Text);
                Globals.global_user.Update();
                result_text.Text = "Withdraw successful!\nYour new balance is:  " + Globals.global_user.Balance;
                sold.Text = "Sold: " + Globals.global_user.Balance.ToString();
            }
            else
            {
                result_text.Foreground = Brushes.OrangeRed;
                result_text.Text = "Withdraw failed!\nYour balance is:  " + Globals.global_user.Balance;
            }


        }
    }
}
