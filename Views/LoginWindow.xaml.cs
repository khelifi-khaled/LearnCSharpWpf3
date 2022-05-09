using LearnCSharpWpf3.ViewModels;
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

namespace LearnCSharpWpf3.Views
{
    public partial class LoginWindow : Window
    {
        private MainWindowVM MwVM { get; set; }


        public LoginWindow(MainWindowVM mwvm)

        {
            InitializeComponent();
            MwVM = mwvm;
        }
        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            MwVM.UserConnected = MwVM.Users.TryLogin(TextBoxLogin.Text, TextBoxPassword.Text);
            if (MwVM.UserConnected != null)
            {
                this.Close();
            }
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
    }
