using System;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public class SalesMan : User
    {
        public SalesMan() { }

        public SalesMan (DateTime birthday, string lastName = "LastName", string firstName = "FirstName", int idUser = 0, int levelAccess = 1, string password = "Password01", string picture = "", bool gender = true)
        : base(birthday, lastName, firstName, idUser, levelAccess, password, picture, gender)
        {

        }

        /// <summary>
        /// wage calculation from base salary
        /// </summary>
        public override void WageCalculation()
        {
            MessageBox.Show($"Ceci est la méthode  de calcul du salaire pour { FullName }de type {this.GetType()} et qui tient compt des primes");

        }//end WageCalculation



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