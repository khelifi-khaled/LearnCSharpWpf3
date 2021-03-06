using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Utilities.DataAccess;
using System.ComponentModel;


namespace LearnCSharpWpf3.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;




        private const string USERS_CSV_FILE = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\Utilisateurs.csv";
        private const string USERS_JSON_FILE = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\JsonUtilisateurs.json";
        private const string PHOTOS_PATH_DIR = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\photos\";
        private const string COMPANY_NAME = "SOLUTECH";



        private User _userConnected; 




        public MainWindowVM()
        {

            User.Company = COMPANY_NAME;
            User.PicPathDir = PHOTOS_PATH_DIR;
            //old version with only csv DataAccessV.
          
            //UsersDataAccessCsvFile uda = new UsersDataAccessCsvFile(USERS_CSV_FILE);
            //uncomment if data source is a csv file
            //UsersDataAccess = new UsersDataAccessCsvFile(USERS_CSV_FILE,new string[]{"txt","csv"});
            //uncomment if datas source is a json file
            UsersDataAccess = new UsersDataAccessJsonFile(USERS_JSON_FILE, new string[] { "json" });
            //uncomment if datas source is a xml file
            //UsersDataAccess = new UsersDataAccessXmlFile(USERS_XML_FILE, new string[]{"xml","txt"});
            Users = UsersDataAccess.GetUsersDatas(); //get users collection datas from DataAccessSource(csv, json...).


            


            // pour exporter les fichiers de csv au json

            //UsersDataAccessJsonFile UsersDataAccessForJsonSave = new UsersDataAccessJsonFile(@"C:\temp\JsonUtilisateurs.json", new string[] { "json" });
            //UsersDataAccessForJsonSave.UpdateAllUsersDatas(Users);

            Company = new Company("SOLUTECH", "3 Boulevard de la victoire 7000 Mons", "BE 0123.654.789", "info@solutech.com", Users);


        }//end constructeur 






        private bool _isConnected = false;

        public bool IsConnected
        {
            get
            {
                return _isConnected;

            }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));

            }
        }




        private bool _isNotConnected = true;

        public bool IsNotConnected
        {
            get
            {
                return _isNotConnected;

            }
            set
            {
                _isNotConnected = value;
                OnPropertyChanged(nameof(IsNotConnected));

            }
        }




        /// <summary>
        /// Collection of all users in the databse (source file)
        /// </summary>
        public UserCollection Users { get; set; }

        public Company Company { get; set; }

        /// <summary>
        /// Manager to the users data access (Csv, Json, XAML, SQL...)
        /// </summary>
        public UsersDataAccess UsersDataAccess { get; set; }



        /// <summary>
        /// Logged user to this application
        /// </summary>
        public User UserConnected
        {
            get => _userConnected;
            set
            {
                _userConnected = value;
                OnPropertyChanged(nameof(UserConnected));
                IsConnected = UserConnected != null;
                IsNotConnected = UserConnected == null;
            }
        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }//end class 

}//end class 
