using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Utilities.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharpWpf3.ViewModels
{
    public class MainWindowVM
    {
        private const string USERS_CSV_FILE = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\Utilisateurs.csv";
        private const string USERS_JSON_FILE = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\JsonUtilisateurs.json";
        private const string PHOTOS_PATH_DIR = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\photos\";
        private const string COMPANY_NAME = "SOLUTECH";
        public MainWindowVM()
        {

            User.Company = COMPANY_NAME;
            User.PicPathDir = PHOTOS_PATH_DIR;
            //old version with only csv DataAccessV.
          
            //UserDataAccessCsvFile uda = new UserDataAccessCsvFile(USERS_CSV_FILE);
            //uncomment if data source is a csv file
            //UsersDataAccess = new UsersDataAccessCsvFile(USERS_CSV_FILE,new string[]{"txt","csv"});
            //uncomment if datas source is a json file
            UsersDataAccess = new UsersDataAccessJsonFile(USERS_JSON_FILE, new string[] { "json" });
            //uncomment if datas source is a xml file
            //UsersDataAccess = new UsersDataAccessXmlFile(USERS_XML_FILE, new string[]{"xml","txt"});
            Users = UsersDataAccess.GetUsersDatas(); //get users collection datas from DataAccessSource(csv, json...).
        }


        /// <summary>
        /// Collection of all users in the databse (source file)
        /// </summary>
        public UserCollection Users { get; set; }

        /// <summary>
        /// Manager to the users data access (Csv, Json, XAML, SQL...)
        /// </summary>
        public UsersDataAccess UsersDataAccess { get; set; }


    }//end class 

}//end class 
