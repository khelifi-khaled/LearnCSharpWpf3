using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharpWpf3.Models
{
    public  class Company
    {

        public Company(string name, string postalAddress, string vatNumber, string email, UserCollection users )
        {
            Name = name;
            PostalAddress = postalAddress;
            VatNumber = vatNumber;
            Email = email;
            Users = users;


        }
        public string Name { get; set; }
        public string PostalAddress { get; set; }
        public string VatNumber { get; set; }
        public string Email { get; set; }
        public int EmployeesNumber => Users != null ? Users.Count : 0;
        private UserCollection Users { get; }


    }//end class Company
}//end project 
