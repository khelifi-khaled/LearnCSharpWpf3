using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace LearnCSharpWpf3.Utilities.DataAccess
{
    public abstract class UsersDataAccess : IUsersDataAccess
    {
        private string _accessPath;


        public UsersDataAccess(string filePath)
        {
            AccessPath = filePath;
        }


        public UsersDataAccess(string filePath, string[] extensions)
        {
            Extensions = new List<string>(extensions.ToList());
            AccessPath = filePath;

        }


        /// <summary>
        /// AccessPath file to the data source
        /// </summary>
        public virtual string AccessPath
        {
            get => _accessPath;

            set
            {
                if (CheckAccessPath(value))
                {
                    _accessPath = value;
                }
            }
        }
        public abstract UserCollection GetUsersDatas();

        public abstract void UpdateAllUsersDatas(UserCollection uc);

        public abstract void UpdateUserDatas(User u);

        /// <summary>
        /// List of authorized extensions .txt, csv, .Json, .xml ...for the AccessPath file
        /// </summary>
        private List<string> Extensions { get; set; }

        /// <summary>
        /// Continue to check AccessPath even after constructor (in the case of the file may be moved, renamed or deleted)
        /// </summary>
        public bool IsValidAccessPath => CheckAccessPath(AccessPath);


        /// <summary>
        /// Check AccessPath to the data source file. File path must exist and if
        /// extensions are specified, the extension file must match to one of them
        /// </summary>
        /// <returns>
        /// true if valid path and extension file
        /// </returns>


        private bool CheckAccessPath(string tryPath)
        {
            if (File.Exists(tryPath))
            {
                if (Extensions?.Any() ?? false)
                {
                    string pattern = "";
                    foreach (string ext in Extensions)
                    {
                        pattern += ext + "|";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 1);
                    //check extension file
                    if (!Regex.IsMatch(tryPath, pattern + "$")) //pattern exemple = ".txt|.csv$"
                    {
                        MessageBox.Show($"L'extension du fichier {tryPath} n'est pas valide, extensions attendues{ pattern}", "Erreur de fichier", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show($"Le fichier {tryPath} n'existe pas", "Erreur de fichier", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            
            }
        }
    }
}//end UsersDataAccess 

