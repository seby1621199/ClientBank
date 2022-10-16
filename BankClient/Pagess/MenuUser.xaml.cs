using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankClient.Pagess
{
    /// <summary>
    /// Interaction logic for MenuUser.xaml
    /// </summary>
    public partial class MenuUser : Window
    {
        public MenuUser()
        {
            InitializeComponent();
        }

        private void Btn_Home_Click(object sender, RoutedEventArgs e)
        {
            btn_Home.Background = Brushes.Transparent;
            btn_Transfer.Background = Brushes.Transparent;
            btn_Deposit.Background = Brushes.Transparent;
            btn_Withdraw.Background = Brushes.Transparent;
            btn_Accounts.Background = Brushes.Transparent;
            Page.Content = null;
            if (sender == btn_Home)
                Page.Content = new Home();
            if (sender == btn_Deposit)
                Page.Content = new Deposit();
            if (sender == btn_Withdraw)
                Page.Content = new Withdraw();
            if (sender == btn_Transfer)
                Page.Content = new Transfer();
            if (sender == btn_Accounts)
                Page.Content = new SelectAccount();



            Button button = sender as Button;
            button.Background = new SolidColorBrush(Color.FromRgb(103, 58, 183));

        }


    }
}
