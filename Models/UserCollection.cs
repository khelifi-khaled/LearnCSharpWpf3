using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharpWpf3.Models
{ 
    public class UserCollection : ObservableCollection<User>
    {


        public void AddUser(User u)
        {
            this.Add(u);
        }

    }//end class 

    }//end project 
