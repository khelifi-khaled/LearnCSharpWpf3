using CsvHelper;
using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace LearnCSharpWpf3.Utilities.DataAccess
{ 
    public class UsersDataAccessCsvFile : UsersDataAccess,IUsersDataAccess
    {

        public UsersDataAccessCsvFile(string filePath) : base(filePath) { }
        public UsersDataAccessCsvFile(string filePath, string[] extensions) : base(filePath, extensions)
        { }
        /// <summary>
        /// retrieve Users collection datas from the datasource csv file
        /// </summary>
        public override UserCollection GetUsersDatas()
        {
            UserCollection users = new UserCollection();
            List<string> listToRead = new List<string>();
            //lecture d'un fichier csv et stockage dans une List de string
            if (IsValidAccessPath)
            {
                listToRead = File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    //Console.WriteLine(s);
                    User u = GetUser(s);
                    users.Add(u);
                }
                return users;
            }
            else
            {
                return null;
            }
        }




        private  User  GetUser(string line)
        {
                string[] fields = line.Split(',');
                switch (fields[0])
                { 
                    case "Electrician":

                        return new Electrician(int.Parse((fields[11])) != 0 ? true : false, int.Parse((fields[12])) !=0 ? true : false, int.Parse((fields[12])) != 0 ? true : false, int.Parse((fields[10])) != 0 ? true : false, double.Parse((fields[15])), DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);
                    case "Secretary":
                    return new Secretary(DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse( fields[3]), int.Parse(fields[5]),fields[6],fields[8],int.Parse(fields[4])!=0? true:false) ;

                    case "Mechanic":
                        return new Mechanic(int.Parse((fields[11])) != 0 ? true : false, int.Parse((fields[14])) == 1 ? true : false, int.Parse((fields[10])) != 0 ? true : false, double.Parse((fields[15])), DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);

                    case "DirHumanRessources":
                        return new DirHumanRessors(DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);

                    case "WorkShopSupervisor":
                        return new WorkshopSupervisor(DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);

                    case "SalesMan":

                        return  new SalesMan(DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);

                    case "CEO":

                        return  new CEO(DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);
                      

                    case "AccountingOfficer":
                        return  new AccountingOfficer(DateTime.Parse(fields[7]), fields[2], fields[1], int.Parse(fields[3]), int.Parse(fields[5]), fields[6], User.PhotosPathDir + fields[8], int.Parse((fields[4])) != 0 ? true : false);
                    default:

                        return null;

                

                }//end use case 

               

               

        }//end GetUsersDatas

        public override  void UpdateAllUsersDatas(UserCollection uc) 
        {

              List<User> users = uc.ToList();


            if (IsValidAccessPath)
            {
                string headerLine = string.Join(",", users[0].GetType().GetProperties().Select(x => x.Name));


                var DataLines = from c in users
                                let DataLine = string.Join(",", c.GetType().GetProperties().Select(y=>y.GetValue(c)))
                                select DataLine;

                var csvDatas = new List<string>();

                csvDatas.Add(headerLine);

                csvDatas.AddRange(DataLines);

                File.WriteAllLines(AccessPath, csvDatas);
            }
            else
            {
                Console.WriteLine("UpdateAllUsersDatas error can't update datasource file");
            }
        }

        public override void UpdateUserDatas(User u) { }

    }//end UsersDataAccessCsvFile


}//end project 
