using LearnCSharpWpf3.Models;





namespace LearnCSharpWpf3.Utilities.Interfaces
{
    public interface IUsersDataAccess
    {
        /// <summary>
        /// Access string to the external source (file path, connections tring ...)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }

       


        /// <summary>
        /// retrieve user's informations from the external source
        /// </summary>
        /// <returns>a UserCollection </returns>
        UserCollection GetUsersDatas();
        /// <summary>
        /// update all users datas from the user collection to the external source
        /// </summary>
        /// <param name="uc"></param>
        void UpdateAllUsersDatas(UserCollection uc);
        /// <summary>
        /// update datas for a specific user to the external source
        /// </summary>
        /// <param name="u"></param>
        void UpdateUserDatas(User u);


    }//end IUsersDataAccess interface 
}
