using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Utilities.DataAccess;
using System.Windows;

namespace LearnCSharpWpf3.Views
{
    public partial class PersonalDatasWindow1 : Window
    {

        private  User  ThisUser { get; set; }

        private UsersDataAccess UsersDataAccess { get; set; }

        private UserCollection Users { get; set; }





        public PersonalDatasWindow1(User u , UserCollection users , UsersDataAccess uda  )
        {
            ThisUser = u;
            Users = users;
            DataContext = ThisUser;
            InitializeComponent();
            UsersDataAccess = uda;


        }


        private void ButtonSauver_Click(object sender, RoutedEventArgs e)
        {
            UsersDataAccess.UpdateAllUsersDatas(Users);
            

        }

        private void ButtonQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
