using LearnCSharpWpf3.Models;
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
    /// <summary>
    /// Logique d'interaction pour CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {


        public CompanyWindow(Company c)
        {
            ThisCompany = c;
            InitializeComponent();
            TxtName.Text = c.Name; 
            TxtAddress.Text = c.PostalAddress;
            TxtEMail.Text = c.Email;
            TxtVAT.Text = c.VatNumber;
            TxtEmployeesNum.Text = c.EmployeesNumber.ToString();


        }
        Company ThisCompany { get; set; }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ThisCompany.Name = TxtName.Text;
        }
    }
}
