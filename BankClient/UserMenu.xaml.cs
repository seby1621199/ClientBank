using System;
using System.Windows;
using System.Windows.Input;

namespace BankClient
{
    /// <summary>
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void check_balance_MouseHover(object sender, EventArgs e)
        {
            check_balance_button.Opacity = 70;

        }
        private void Window_Mouse(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
    }
}
