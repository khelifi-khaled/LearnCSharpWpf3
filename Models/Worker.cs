using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    abstract public class Worker : User
    {
        private DateTime _departureDateTime;
        private DateTime _incomongDateTime;
        private bool _isBA4;
        private bool _isOnCall;
        private double _overTime;
        private bool _warningWorktime;
        private const int NOMAL_MIN_DURANTION = (8 * 60) + 30;//temps normal passé dans le société en mint
        private string _fullName ; 






        public Worker() { }


       
        public Worker(bool isBA4, bool isOnCall, double overtime, DateTime birthday, string lastName = "Lastname", string firstName = "Firstname", int idUser = 0, int levelAccess = 1, string password= DEFAULT_PASSWD , string picture = "", bool gender = true , string fullName = "" )
        :base(birthday, lastName, firstName, idUser, levelAccess, password, picture, gender)
        {
            _isBA4 = isBA4;
            _isOnCall = isOnCall;
            _overTime = overtime;
            _warningWorktime = false;
            _fullName = fullName;
            //_incomingDateTime= //affecté au moment d'un passage de badge
            //__departureDateTime //affecté au moment d'un passage de badge
        }


        public string FullName
        {
            get
            {
                _fullName = $"{LastName} {FirstName}";
                return _fullName;
            }

            set
            {

            }
        }

        /// <summary>
        /// Departure date time of the worker
        /// </summary>
        public DateTime DepartureDateTime
        {
            get => _departureDateTime;
            set
            {
                _departureDateTime = value;
                ComputeOvertime();
            }
        }

        public DateTime IncomongDateTime
        {
            get
            {
                return _incomongDateTime;
            }
            set
            {
            }
        }

        public bool IsBA4
        {
            get 
            {
                return _isBA4;
            }
            set
            {
            }
        }

        public bool IsOnCall
        {
            get
            {
                return _isOnCall;
            }
            set
            {
            }
        }

        public double OverTime
        {
            get
            {
                return _overTime;
            }
            set
            {
            }
        }

        public bool WarningWorktime
        {
            get
            {
                return _warningWorktime;
            }
            set
            {
            }
        }


        /// <summary>
        /// compute overtime in complete half hours
        /// </summary>
        public void ComputeOvertime()
        {
            const int NORMAL_MIN_DURATION = (8 * 60) + 30; //temps normal passé dans la société enminutes
            if (DepartureDateTime != default && IncomongDateTime != default)
            {
                TimeSpan workTime = DepartureDateTime.Subtract(IncomongDateTime);
                double overTimeInMin = workTime.TotalMinutes - NORMAL_MIN_DURATION; //((8 * 60) +30) //95,6 minutes
                double overTimeExactHalfHours = overTimeInMin / 30; //ex : exact half hours number ex : 3,187 half hours
                int overTimeFullHalfHours = Convert.ToInt32(Math.Floor(overTimeExactHalfHours)); // full complete half hours ex : 3,187 half hours become 3
                OverTime = overTimeFullHalfHours * 0.5; //overtime in hours 0, 0.5, 1, 1.5, 2, 2.5,...
            }//end if 
        }//end ComputeOvertime
        public void VerifyWorkTime()
        {
        }

        public override void WageCalculation()
        {
            MessageBox.Show($"Ceci est la méthode de calcul du salaire pour {FullName} de type {this.GetType()} et qui tient compte d'un tarif horaire");
        }



        /// <summary>
        /// show main personnal datas for a worker
        /// </summary>
        public override void ShowPersonalDatas()
        {
            MessageBox.Show($"Voici d'autres infos, l'ouvrier {FullName} est de garde ? :{IsOnCall}");
        }


      


    }
}