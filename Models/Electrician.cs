using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public class Electrician : Worker
    {
        private bool _highVoltage;
        private bool _isBA5;

        public Electrician()
        {
          
        }

        public Electrician(bool isBA4 = false, bool isBA5 = false, bool highVoltage = false, bool isOnCall = false, double overtime = 0, DateTime birthday = default(DateTime), string lastName = "Lastname", string firstName = "Firstname", int idUser = 0, int levelAccess = 1, string password="Password01", string picture = "", bool gender = true)
        :base(isBA4, isOnCall, overtime, birthday, lastName, firstName, idUser, levelAccess, password,picture, gender)
        {
            _isBA5 = isBA5;
            _highVoltage = highVoltage;
        }

        public bool HighVoltage
        {
            get
            {
                return _highVoltage;
            }
            set
            {
            }
        }

        public bool IsBA5
        {
            get 
            {
                return _isBA5;
            }
            set

            {
            }
        }

        /// <summary>
        /// show main properties for an electrician
        /// </summary>
        public override void ShowPersonalDatas()
        {
            MessageBox.Show($"Voici d'autres infos : l'électricien {FullName} est de garde ? :{IsOnCall} et BA5 ?:{IsBA5}");
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
