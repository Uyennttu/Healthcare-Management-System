using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_Management_System
{
    public abstract class Person
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        protected Person(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract string DisplayInfo();

       

    }
           
}
