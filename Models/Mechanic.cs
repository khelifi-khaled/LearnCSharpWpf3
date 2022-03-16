using System;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public class Mechanic : Worker
    {
        private bool _isWelder;

        public Mechanic()
        {
           
        }
        public Mechanic(bool isBA4 = false, bool isWelder = false, bool isOnCall = false, double overtime = 0, DateTime birthday = default(DateTime), string lastName = "Lastname", string firstName = "Firstname", int idUser = 0, int levelAccess = 1, string password = "Password01", string picture = "", bool gender = true)
        : base(isBA4, isOnCall, overtime, birthday, lastName, firstName, idUser, levelAccess, password, picture, gender)
        {
            _isWelder = isWelder;

        }

        public bool IsWelder
        {
            get
            {
                return _isWelder;
            }
            set
            {
            }
        }

        /// <summary>
        /// specific reporting for this class
        /// </summary>
        /// <param name="prj"></param>
        /// 
        public override void ReportDailyActivity(int idPrj)
        {
            MessageBox.Show($"Ceci est le rapport spécifique pour {this.GetType()}");
        }
    }
}