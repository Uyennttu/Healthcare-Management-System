using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_Management_System
{
    public class Appointment
    {
        public string Id;
        public Patient Patient;
        public Doctor Doctor;
        public DateTime DateTime;
        public string MedicalHistory;
        
        public Appointment(string id, Patient patient, Doctor doctor, DateTime datetime, string medicalHistory) 
        { 
            Id= id;
            Patient= patient;
            Doctor= doctor;
            DateTime = datetime;
            MedicalHistory = medicalHistory;

        }
        public void DisplayAppointment()
        {
            Console.WriteLine($"ID: {Id} ---Patient Name: {Patient.FirstName} {Patient.LastName} " +
            $"---Doctor Name: {Doctor.FirstName} {Doctor.LastName}\n" +
            $"---Patient's Medical History: {Patient.MedicalHistory} " +
            $"---Appointment Time: {DateTime}.");
        }

            
        
    }
}
