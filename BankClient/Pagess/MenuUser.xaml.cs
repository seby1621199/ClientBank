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
    /// Interaction logic for MenuUser.xaml
    /// </summary>
    public partial class MenuUser : Window
    {
        public MenuUser()
        {
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            btn_Home.Background = Brushes.Transparent;
            btn_Transfer.Background = Brushes.Transparent;
            btn_Deposit.Background = Brushes.Transparent;
            btn_Withdraw.Background = Brushes.Transparent;
            Page.Content = null;
            if(sender==btn_Home)
                Page.Content = new Home();
            if (sender == btn_Deposit)
                Page.Content = new Deposit();
            if (sender == btn_Withdraw)
                Page.Content = new Withdraw();
            if (sender == btn_Transfer)
                Page.Content = new Transfer();



            Button button = sender as Button;
            button.Background = new SolidColorBrush(Color.FromRgb(103, 58, 183));
            
        }
        
        
    }
}
