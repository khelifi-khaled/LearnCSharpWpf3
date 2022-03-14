using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnCSharpWpf3.Models
{ 
    public class UserCollection : ObservableCollection<User>
    {


        /// <summary>
        /// try to find a user in the collection by his/her Login
        /// </summary>
        /// <param name="tryLogin"></param>
        /// <returns>reference to the user in this user's collection, with a match on the login</returns>
        private User GetUserByLogin(string tryLogin)
        {
            return this.ToList().Find(u => u.Login.Equals(tryLogin));
        }
        /// <summary>
        /// Try to login an application's user
        /// </summary>
        /// <param name="tryLogin"></param>
        /// <param name="tryPassword"></param>
        /// <returns>reference to the logged user in the user's collection </returns>
        public User TryLogin(string tryLogin, string tryPassword)
        {
            User u = GetUserByLogin(tryLogin);
            if (u != null)
            {
                if (u.IsRightPassword(tryPassword))
                {
                    MessageBox.Show($"Nouvel utilisateur loggé {u.FullName}", "Login effectué",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    return u;
                }
             
                else
                {
                    MessageBox.Show("Mot de passe incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            else //login user not found
            {
                MessageBox.Show("Login incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void AddUser(User u)
        {
            this.Add(u);
        }

    }//end class 

    }//end project 
