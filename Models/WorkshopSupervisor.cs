using System;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public class WorkshopSupervisor : User
    {


        public WorkshopSupervisor() { }

        public WorkshopSupervisor(DateTime birthday, string lastName = "LastName", string firstName = "FirstName", int idUser = 0, int levelAccess = 1, string password = DEFAULT_PASSWD , string picture = "", bool gender = true)
        : base(birthday, lastName, firstName, idUser, levelAccess, password, picture, gender)
        {

        }

        public void EquipmentOrder()
        {
            if (this.Password==DEFAULT_PASSWD)
            {
                MessageBox.Show("vous  ne peouvez pas effectuer votre commande , vous devez change votre password ", "Erreur ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Une commande va être réalisée", "confirmation de bon de commend ", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }//end EquipmentOrder

        /// <summary>
        /// specific reporting for this class
        /// </summary>
        /// <param name="prj"></param>
        public override void ReportDailyActivity(int idPrj)
        {
            MessageBox.Show($"Ceci est le rapport spécifique pour {this.GetType()}");
        }

    }//end class 
}//end project 