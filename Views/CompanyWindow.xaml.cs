using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Views;
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
            DataContext = ThisCompany;
            InitializeComponent();

        }
        Company ThisCompany { get; set; }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonChangeObjectProperties_Click_2(object sender, RoutedEventArgs e)
        {
            ThisCompany.Name = "ELECTRATECH";
            ThisCompany.PostalAddress = "19 rue des arbalestriers 1000 Bruxelles";
            ThisCompany.Email = "contact@electratech.com";
            ThisCompany.VatNumber = "BE 4444.719.444";
            //ajouter un utilisateur.

        }

        private void ButtonShowObjectProperties_Click_1(object sender, RoutedEventArgs e)
        {
            ThisCompany.ShowProperties();
        }
    }
}
