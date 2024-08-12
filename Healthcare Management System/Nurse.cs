using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_Management_System
{
    public class Nurse : Person
    {
        public string Department;
        public int Experience;
        public Nurse(string id,string firstName, string lastName, string department, int experience): base(id,firstName, lastName) 
        {
            Department = department;
            Experience = experience;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id, -5} " +
                $"Name: {FirstName} {LastName, -7} " +
                $"Department: {Department, -15} " +
                $"Experience: {Experience} years");
        }
        
    }

}
