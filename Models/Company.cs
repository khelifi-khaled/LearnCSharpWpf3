using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace LearnCSharpWpf3.Models
{
    public  class Company : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;



        private string _vatNumber;
        private string _email;
        private String _name;
        private string _postalAddress;
       

        public Company(string name, string postalAddress, string vatNumber, string email, UserCollection users )
        {
            Name = name;
            PostalAddress = postalAddress;
            VatNumber = vatNumber;
            Email = email;
            Users = users;


        }

        
        public string VatNumber
        {
            get => _vatNumber;
            set
            {
                if (CheckBelgianVatNumber(value))
                {
                    _vatNumber = value;
                    OnPropertyChanged(nameof(VatNumber));
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (CheckBelgianEMail(value))
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        private bool CheckBelgianVatNumber(string VAT)
        {
            /*format accepté semblable à "BE 4444.719.444";
            obligatoirement BE puis obligatoirement 4 caractères entre 0 et 9, obligatoirement un
            point
            puis obligatoirement 3 caractères entre 0 et 9 puis obligatoirement un point puis de
            nouveau
            obligatoirement 3 caractères entre 0 et 9*/
            if (!Regex.IsMatch(VAT, @"^BE [0-9]{4}\.[0-9]{3}\.[0-9]{3}$"))
            {
            MessageBox.Show($"Le N° de TVA doit être au format BE XXXX.XXX.XXX", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
            }
            return true;
        }
        private bool CheckBelgianEMail(string email)
        {
            /*format accepté semblable à "a@b.com";
            obligatoirement de 1 à 20 caractères de a z, 0 à 9 puis obligatoirement le @ puis
            obligatoirement de 1 à 15 caractère de a z, 0 à 9 puis un . puis soit com, org ou be*/
            if (!Regex.IsMatch(email, @"^[a-z0-9]{1,20}@[a-z0-9]{1,15}\.(com|org|be)$"))
            {
                MessageBox.Show($"L'adresse mail est incorrecte", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        public string Name 
        { get => _name ; 
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string PostalAddress 
        {
            get => _postalAddress;
            set
            {
                _postalAddress = value;
                OnPropertyChanged(nameof(PostalAddress));
            }

        }

        

        public int EmployeesNumber => Users != null ? Users.Count : 0;
        private UserCollection Users { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowProperties()
        {
            MessageBox.Show($"Nom: {this.Name}\nAdresse: {this.PostalAddress}\nN°TVA: {this.VatNumber}\nEMail: {this.Email}\nNombre d'employés: {this.EmployeesNumber}");
        }


    }//end class Company
}//end project 
