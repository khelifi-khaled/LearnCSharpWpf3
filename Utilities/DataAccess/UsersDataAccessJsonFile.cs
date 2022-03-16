using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.Utilities.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;


namespace LearnCSharpWpf3.Utilities.DataAccess
{
    public  class UsersDataAccessJsonFile : UsersDataAccess , IUsersDataAccess
    {
        public UsersDataAccessJsonFile(string filePath) : base(filePath) { }


        public UsersDataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions) { }

  

        /// <summary>
        /// retrieve Users collection datas from the datasource Json file
        /// </summary>
        public override UserCollection GetUsersDatas()
        {
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);

                UserCollection users = new UserCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)

                JsonSerializerSettings settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All };

                users = JsonConvert.DeserializeObject<UserCollection>(jsonFile, settings);

                return users;
            }
            else
            {
                //Console.WriteLine("GetUsersDatas File doesnt exist");
                return null;
            }
        }//end GetUsersDatas





        /// <summary>
        /// update json source file from the users collection
        /// </summary>
        /// <param name="uc"></param>
        /// 


        public override void UpdateAllUsersDatas(UserCollection uc)
        {
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.All};

                string json = JsonConvert.SerializeObject(uc, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllUsersDatas error can't update datasource file");
            }
        }//end UpdateAllUsersDatas 


        public override void UpdateUserDatas(User u) 
        { }


    } //end class

}//end project 

