﻿using System;
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
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : UserControl
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void btn_withdraw_Click(object sender, RoutedEventArgs e)
        {
            result_text.Foreground = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            if (Globals.global_user.Balance >= uint.Parse(input_amount.Text))
            {
                Globals.global_user.Balance = Globals.global_user.Balance - uint.Parse(input_amount.Text);
                Globals.global_user.Update();
                result_text.Text = "Withdraw successful!\nYour new balance is:  " + Globals.global_user.Balance;
            }
            else
            {
                result_text.Foreground = Brushes.OrangeRed;
                result_text.Text = "Withdraw failed!\nYour balance is:  " + Globals.global_user.Balance;
            }


        }
    }
}