using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public class TechnicalDir : User
    {


        public TechnicalDir() { }

        public TechnicalDir(DateTime birthday, string lastName = "LastName", string firstName = "FirstName", int idUser = 0, int levelAccess = 1, string password = DEFAULT_PASSWD , string picture = "", bool gender = true)
        : base(birthday, lastName, firstName, idUser, levelAccess, password, picture, gender)
        { 
        
        }


        /// <summary>
        /// change password with a new random password generation (ex : 3Fxrthye)
        /// <summary>
        public void RandomPasswordChange()
        {
            string randPassword;
            Random rd = new Random();
            randPassword = ((char)rd.Next(48, 57)).ToString(); //generate random char between 0 and 9
            randPassword += ((char)rd.Next(65, 90)).ToString(); //generate random upper case char between A and Z

            //generate random lower case chars between 97 and 122
            for (int i = 2; i < User.MIN_CHAR_PASSWORD; i++)
            {
                randPassword += ((char)rd.Next(97, 122)).ToString();
            }
            Console.WriteLine(randPassword);
            this.Password = randPassword;//change password
                                         //notify this new password by email
        }//end RandomPasswordChange

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