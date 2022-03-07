using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


namespace LearnCSharpWpf3.Models
{
    abstract public class User
    {

        //const 
        protected const string DEFAULT_PASSWD = "Password01";



        protected static int MIN_CHAR_PASSWORD = 8;
        protected static int MAX_CHAR_PASSWORD = 20;


        //déclaration des champs de classe
        private string _lastName;
        private string _firstName;
        private int _levelAccess;
        private string _login;
        private string _password;
        private int _idUser;
        private bool _gender;
        private string _picture;
        private DateTime _birthday;
        private static string _company;
        private static string _PhotosPathDir;
        private static string _picPathDir;
        private  string _displayedImagePath;



        public User ()
        { 
        
        }


         
        public User(DateTime birthday, string lastName = "Lastname", string firstName = "Firstname", int idUser = 0, int levelAccess = 1, string password = DEFAULT_PASSWD , string picture = "", bool gender = true)
        {
            _lastName = lastName;
            _firstName = firstName;
            BuildLogin();
            _idUser = idUser;
            _levelAccess = levelAccess;
            _password = password;
            _gender = gender;
            _birthday = birthday;
            _picture = picture;
            


       

           
    }//end 

        
        public static string PicPathDir { get => _picPathDir; set => _picPathDir = value; }
        /// <summary>
        /// Full path of the user's picture file . Ex:"C:\\IRAM PS\\Cours\\POO...\\dupont.jpg"
        /// </summary>
        public string DisplayedImagePath
        {
            get
            {
                return _displayedImagePath;
            }//fin get
            set
            {
                _displayedImagePath = value;
            }
        }

        public string EMail { get; set; }

        public bool IsSafePassword => this.Password != DEFAULT_PASSWD;


        public string FullName 
        {
            get
            { 
                return  _firstName + " "+  _lastName;
            }
            set
            {

            }
        }

        [JsonProperty]
        public int IdUser { 
            get 
            {
                return _idUser;
            } 
            private  set 
            {
                _idUser = value;
            } 
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (CheckEntryName(value))
                {
                    _firstName = value;
                    BuildLogin();
                } 
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (CheckEntryName(value))
                {
                    _lastName = value;
                    BuildLogin();
                }
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }

        [JsonProperty]
        protected string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (CheckPassword(value, this.FirstName, this.LastName))
                    _password = value;
            }
        }

        public bool Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        [JsonProperty]
        public int LevelAccess
        {
            get
            {
                return _levelAccess;
            }
            private set
            {
                _levelAccess = value;
            }
        }

        /// <summary>
        /// file name and extension for the user's picture. Ex:"dupont.jpg"
        /// </summary>
        public string Picture
        {
            get
            {
                return _picture;
            }//fin get
            set
            {
                if (CheckPicture(PicPathDir + value))
                {
                    _picture = value;
                    DisplayedImagePath = $"{PicPathDir}{Picture}";
                }
            }//fin set
        }


        [JsonConverter(typeof(CustomDateTimeConverter),"dd-MM-yyyy")]
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (CheckIsAdult(value))
                {
                    _birthday = value;
                }


            }
        }

        static public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
        }

        static public string PhotosPathDir
        {
            get
            {
                return _PhotosPathDir;
            }
            set
            {
                _PhotosPathDir = value;
            }
        }

        /// <summary>
        /// Check LastName or FirstName
        /// MAJ start each part, no double space or -, no special character, no accented character like éèê
        /// ex: Pierre-Jean-Henri De La Fontaine -> accepted
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static private bool CheckEntryName(string name)
        {
            //name = "P- Henri";
            //si le nom débute ou termine par un espace ou un tiret
            if (name.StartsWith(" ") || name.StartsWith("-") || name.EndsWith(" ") || name.EndsWith("-"))
            {
                MessageBox.Show($"La saisie {name} ne peut commencer ou se terminer par un espace ou un tiret", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //si le nom contient au moins un double espace.
            if (name.Contains("  ") || name.Contains("--"))
            {
                MessageBox.Show($"La saisie {name} comporte au moins un double espace ou tiret non autorisé", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //test s'il y a présence de caractère spéciaux (en dehors de l'alphabet) ou accentués sans tenir compte d'un espace ou un tiret (derrière le Z: Z -)
            if (!Regex.IsMatch(name, @"^[a-zA-Z -]*$"))
            {
                MessageBox.Show($"La saisie {name} ne peut comporter de caractères spéciaux ou accentués", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            string[] nameParts = name.Split('-', ' ');
            foreach (string s in nameParts)
            {
                //test si la première lettre est une majuscule et les suivantes de a à z en minuscule et sans accent
                if (!Regex.IsMatch(s, @"^[A-Z][a-z]*$"))
                {
                    MessageBox.Show($"La saisie {name} ne correpond pas aux critères. La première lettre de chaque élément qui compose la saisie doit être une majuscule et les suivantes des minuscules.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            //tous les tests concluants, saisie valide.
            return true;
        }//END CheckEntryName

        /// <summary>
        /// Check le chemin d'une photo d'utilisateur -> OK si le chemin est correct, si la photo a une extension correcte et si sa taille est comprise entre tailleMin et tailleMax
        /// </summary>
        /// <param name="picture">Nouveau chemin d'acces pour la photo</param>
        /// <returns></returns>
        static private bool CheckPicture(string picture)
        {
            int tailleMin = 5000;
            int tailleMax = 1000000;
            String[] extension = { ".jpg", ".png" };
            FileInfo photo = new FileInfo(picture);
            if (photo.Exists)
            {
                for (int i = 0; i < extension.Length; i++)
                {
                    if (picture.EndsWith(extension[i]))
                    {
                        if (photo.Length > tailleMin && photo.Length < tailleMax)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("La photo doit faire entre 5KB et 1MB", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning); return false;
                        }
                    }

                }
                MessageBox.Show("La photo ne peut être qu'en format jpg ou png", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning); return false;
            }
            else
            {
                MessageBox.Show("Le chemin spécifié n'est pas valide", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning); return false;
            }

        }//END CheckPicture


        /// <summary>
        /// Check if the access level to change is correct. Then check if the user has the correct level to change someone else's.
        /// If both users are max level, the access cannot be changed.
        /// </summary>
        /// <param name="newLevelAccess"></param>
        /// <param name="userToModidy"></param>
        public void ChangeLevelAccess(int newLevelAccess, User userToModidy)
        {
            const int MIN_LEVEL_ACCESS = 0;
            const int MAX_LEVEL_ACCESS = 4;

            if (newLevelAccess > MAX_LEVEL_ACCESS || newLevelAccess < MIN_LEVEL_ACCESS)
            {
                MessageBox.Show($"Attention! Le niveau d'accès doit être compris entre {MIN_LEVEL_ACCESS} et {MAX_LEVEL_ACCESS}", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }//fin if 1
            else
            {
                if (this.LevelAccess == MAX_LEVEL_ACCESS)
                {
                    if (userToModidy.LevelAccess == MAX_LEVEL_ACCESS)
                    {
                        MessageBox.Show("Vous ne pouvez pas changer le niveau d'accès de cet utilisateur", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }//fin if 3
                    else
                    {
                        MessageBox.Show($"Le nouveau niveau d'accès de {userToModidy.LastName} {userToModidy.FirstName} est {newLevelAccess}", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                        userToModidy.LevelAccess = newLevelAccess;
                    }//fin else 3

                }//fin if 2
                else
                {
                    MessageBox.Show("Vous n'avez pas le niveau pour changer l'accès de cet utilisateur", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }//fin else 2
            }//fin else 1

        }//END ChangeLevelAccess

        /// <summary>
        /// Build Login property from FirstName and LastName : 6 char from Lastname + First char of firstname
        /// </summary>
        private void BuildLogin()
        {
            const int NBR_CHAR_LASTNAME = 6; //number of chars in the lastname
            const int NBR_CHAR_FIRSTNAME = 1; //number of chars in the firstname
                                              //only if firstname et lastname are filled.
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                //to build login, ' ' and '-' perhaps in the fisrtname or lastname are deleted
                string firstNameToUse = Regex.Replace(FirstName, "[ -]", string.Empty);
                string lastNameToUse = Regex.Replace(LastName, "[ -]", string.Empty);
                //only 6 first chars if lastname lenght is longer
                if (lastNameToUse.Length >= NBR_CHAR_LASTNAME)
                {
                    this.Login = lastNameToUse.Substring(0, NBR_CHAR_LASTNAME) +
                    firstNameToUse.Substring(0, NBR_CHAR_FIRSTNAME);//renvoie les 6 premiers de lastName + le 1e de firstName
                }
                else
                {//if lastname's lenght is lesser than 6 all chars are taken
                    this.Login = lastNameToUse + firstNameToUse.Substring(0, NBR_CHAR_FIRSTNAME)
                    ;
                }
            }
        }//END BuildLogin()


        /// <summary>
        /// Password must contains at least a figure 0 to 9, at least one uppercase, only alphanumeric characters not éèàâê
        ///without spaces, at least 8 characters maximum 20. Must not contains firstname, lastname (ingoring case).
        /// </summary>
        /// <param name="password">try password to check</param>
        /// /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>true if valid password</returns>
        static private bool CheckPassword(string password, string firstName, string lastName)
        {
            const int MIN_CHARS = 8;
            const int MAX_CHARS = 20;
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                if (password.ToLower().Contains(firstName.ToLower()) ||
                password.ToLower().Contains(lastName.ToLower()))
                {
                    MessageBox.Show("Le mot de passe ne peut comporter ni votre nom ni votre prénom", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            if (password.Length < MIN_CHARS)
            {
                MessageBox.Show("Le mot de passe doit comporter au moins " + MIN_CHARS + " caractères", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (password.Length > MAX_CHARS)
            {
                MessageBox.Show("Le mot de passe doit comporter maximum " + MAX_CHARS + " caractères", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //test s'il y a présence de caractère spéciaux (en dehors de l'alphabet) ou accentués
            //test si chaque caractère du début à la fin est dans l'intervalle a-z ou A-Z ascii
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]*$"))
            {
                MessageBox.Show($"Le mot de passe ne peut comporter que des lettres de l'alphabet non accentuées", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //test s'il y a présence d'au moins un chiffre nimporte où dans le mot
            //dans ce cas il faut enlevent ^ * sinon cela voudrait dire est ce que tous les caractères du début à la fin sont des chiffres.
            if (!Regex.IsMatch(password, @"[0-9]+"))
            {
                MessageBox.Show($"Le mot de passe doit comporter au moins un chiffre.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!Regex.IsMatch(password, @"[A-Z]+")) //if (!Regex.IsMatch(password, @"^(?=.*[A-Z]).+$"))
            {
                MessageBox.Show($"Le mot de passe doit comporter au moins une majuscule.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        } //END CheckPassword

        /// <summary>
        /// Check if the entry password is the right password for this user
        /// </summary>
        /// <param name="tryPassword"></param>
        /// <returns>true if password is correct</returns>
        private bool IsRightPassword(string tryPassword)
        {
            return tryPassword.Equals(this.Password);
        }//END IsRightPassword


        /// <summary>
        /// Try to change password with a new one. Old password must be entered
        /// </summary>
        /// <param name="oldPassword">actual old password</param>
        /// <param name="newPassword">"new password tried</param>
        /// <param name="confirmNewPassword">"repeat new password to confirm</param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword, string confirmNewPassword
        )
        {
            if (IsRightPassword(oldPassword))//match old password input and actual Password
            {
                if (newPassword.Equals(confirmNewPassword))
                {
                    Password = newPassword; //attempt to modify property

                    return newPassword.Equals(Password); //if attempt is successful, Password and newPassword are equals.
                }
                else
                {
                    MessageBox.Show($"Le nouveau mot de passe et sa confirmation ne correspondent pas",
                    "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"L'ancien mot de passe ne correspond pas.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }//END ChangePassword

        /// <summary>
        /// Check a birthday -> accepted if user is major
        /// </summary>
        /// <param name="newBirthday"> new birthday to test
        /// </param>
        /// <returns>
        /// </returns>
        static private bool CheckIsAdult(DateTime newBirthday)
        {

            const int ADULT_MIN_YEARS = 18;
            if (DateTime.Now >= newBirthday.AddYears(ADULT_MIN_YEARS))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"L'utilisateur doit avoir plus de {ADULT_MIN_YEARS} ans", "Utilisateur non autorisé", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }//END CheckIsAdult



        /// <summary>
        /// wage calculation from base salary
        /// </summary>
        public virtual void WageCalculation()
        {
        MessageBox.Show($"Ceci est la méthode (user) de calcul du salaire pour { FullName }de type {this.GetType()}");

        }//end WageCalculation


        /// <summary>
        /// show main properties about this user
        /// </summary>
        public virtual void ShowPersonalDatas()
        {
            MessageBox.Show($"Voici des infos sur l'utilisateur {FullName} Niveau d'accès :{LevelAccess}");
        }

        /// <summary>
        /// reporting activity, mandatory for each employee's type
        /// </summary>
        public abstract void ReportDailyActivity(int prj);


    }//END CLASS


    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }

        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }


}//END PROJET

