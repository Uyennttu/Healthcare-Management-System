using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Healthcare_Management_System
{
    public class Patient : Person
    {
        public string MedicalHistory;
        public int Age;

        public Patient(string id, string firstName, string lastName, string medicalHistory, int age): base(id, firstName, lastName)
        {
            MedicalHistory = medicalHistory;
            Age = age;
        }
        public override void DisplayInfo()
        {
             Console.WriteLine($"ID: {Id, -5}" +
                $"Name: {FirstName} {LastName, -7}" +
                $"Age: {Age,-5}" +
                $"Medical History: {MedicalHistory}");
        }
        
           
        
    }
}
