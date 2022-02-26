using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public class Secretary : User
    {

        public Secretary() { }

        public Secretary (DateTime birthday, string lastName = "LastName", string firstName = "FirstName", int idUser = 0, int levelAccess = 1, string password = "Password01", string picture = "", bool gender = true)
        : base(birthday, lastName, firstName, idUser, levelAccess, password, picture, gender)
        {

        }

        /// <summary>
        /// specific reporting for this class
        /// </summary>
        /// <param name="prj"></param>
        public override void ReportDailyActivity(int idPrj)
        {
            MessageBox.Show($"Ceci est le rapport spécifique pour {this.GetType()}");
        }

    }
}