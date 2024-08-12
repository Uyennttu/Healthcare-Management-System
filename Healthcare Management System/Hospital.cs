using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_Management_System
{
    public class Hospital
    {
        public List<Patient> patients = new List<Patient> {
            new Patient("1", "John", "Doe", "Diabetes",65),
            new Patient("2", "Jane", "Smith", "Hypertension", 34)
        };

        public List<Nurse> nurses = new List<Nurse>();
        public List<Doctor> doctors = new List<Doctor>
            {
                new Doctor("1", "Sam","Bond ","Cardiology", 2),
                new Doctor("2", "Kat","Igne", "Neurology", 28)
            };
        public List<Appointment> appointments = new List<Appointment>();

        /*public List<MedicalRecord> medicalRecords = new List<MedicalRecord>{
            new MedicalRecord("1",,"high blood level","exercise",),
        };*/


       /* public void ShowMedicalRecord()
        {
            DisplayAllPatients();
            Console.WriteLine("Which patient?");
            var inputPatient=Console.ReadLine();
            if(int.TryParse(inputPatient, out int selectedPatient))
            {
                
            }
            else { Console.WriteLine("Invalid input. Enter a number."); }
        }*/
        public void SearchAppointment(string query)            
        {
            DateTime.TryParse(query, out DateTime queryDate);
            var results = appointments.Where(a =>
            (queryDate != DateTime.MinValue && a.DateTime.Date == queryDate.Date) ||  
            a.Patient.Id.Equals(query, StringComparison.OrdinalIgnoreCase) ||          
            a.Doctor.Id.Equals(query, StringComparison.OrdinalIgnoreCase)).ToList();
            if (results.Any())
            {
                foreach (var result in results)
                {
                    result.DisplayAppointment();
                }
            }
            else
            {
                Console.WriteLine("No appointment found.");
            }
            }
        public void SearchPatient(string query)
        {
            var results = patients.Where(p => p.Id.Equals(query, StringComparison.OrdinalIgnoreCase)
                || (p.FirstName.Equals(query, StringComparison.OrdinalIgnoreCase)) 
                || (p.LastName.Equals(query, StringComparison.OrdinalIgnoreCase))).ToList();
            if (results.Any()) {
                foreach (var result in results) {
                    result.DisplayInfo();
                }
            }
            else { Console.WriteLine("No patient found."); }
        }
        public void SearchDoctor(string query)
        {
            var results = doctors.Where(d => d.Id.Equals(query, StringComparison.OrdinalIgnoreCase)
            || (d.FirstName.Equals(query, StringComparison.OrdinalIgnoreCase))
            || (d.LastName.Equals(query, StringComparison.OrdinalIgnoreCase))
            || (d.Specialty.Equals(query, StringComparison.OrdinalIgnoreCase))).ToList();
            if (results.Any())
            {
                foreach (var result in results)
                {
                    result.DisplayInfo();
                }
            }
            else { Console.WriteLine("No doctor found."); }
        }
        public void CancelAppointment()
        {
            DisplayAllAppointments();
            if (appointments.Count > 0)
            {
                Console.Write("Which number? ");
                var deletion = Console.ReadLine();
                if (appointments.Count() > 0) { }
                if (int.TryParse(deletion, out int deletedNum) && deletedNum > 0 && deletedNum <= appointments.Count())
                {
                    appointments.Remove(appointments[deletedNum - 1]);
                    Console.WriteLine("Appointment was cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else { Console.WriteLine("NO APPOINTMENT."); }
        }

        public void DisplayAllAppointments()
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                Console.Write($"{i + 1}."); appointments[i].DisplayAppointment();
            }
        }

        public void ScheduleAppointment()
        {
            Console.WriteLine("Schedule New Appointment:");
            if (patients.Count == 0 || doctors.Count == 0)
            {
                Console.WriteLine("There must be at least one patient and one doctor to proceed.");
                return;
            }
            else
            {
                DisplayAllPatients();
                Console.Write("Select Patient Id: ");
                var patientId = Console.ReadLine();
                Console.WriteLine("---------------------------");

                DisplayAllDoctors();
                Console.Write("Select Doctor Id: ");
                var doctorId = Console.ReadLine();


                Patient selectedPatient = patients.FirstOrDefault(p => p.Id == patientId);
                Doctor selectedDoctor = doctors.FirstOrDefault(d => d.Id == doctorId);

                if (selectedDoctor == null || selectedPatient == null)
                {
                    Console.WriteLine("Invalid patient or doctor ID.");
                    return;
                }
                Console.Write("Appointment ID: ");
                var id = Console.ReadLine();
                Console.Write("Appointment Date (yyyy-mm-dd HH:mm): ");
                var dateInput = Console.ReadLine();
                if (!DateTime.TryParse(dateInput, out DateTime dateTime))
                {
                    Console.WriteLine("Invalid date and time format.");
                    return;
                }
                Appointment appointment = new Appointment(id, selectedPatient, selectedDoctor, dateTime, selectedPatient.MedicalHistory);
                appointments.Add(appointment);
                Console.WriteLine("Appointment was scheduled successfully!");
            }
        }
            public void RemovePatient()
        {
            DisplayAllPatients();
            if (patients.Count > 0)
            {
                Console.Write("Which number? ");
                var deletion = Console.ReadLine();
                if (patients.Count() > 0) { }
                if (int.TryParse(deletion, out int deletedNum) && deletedNum > 0 && deletedNum <= patients.Count())
                {
                    patients.Remove(patients[deletedNum - 1]);
                    Console.WriteLine("Patient was removed successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else { Console.WriteLine("NO PATIENT."); }
        }
        public void DisplayAllPatients()
        {
            for (int i = 0; i < patients.Count; i++)
            {
                Console.Write($"{i + 1}."); patients[i].DisplayInfo();
            }
        }
        public void AddPatient()
        {
            Console.WriteLine("Add New Patient:");
            Console.Write("ID: ");
            var id = Console.ReadLine();
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Medical History: ");
            var medicalHistory = Console.ReadLine();
            Console.Write("Age: ");
            var age = Console.ReadLine();
            int.TryParse(age, out int numOfAge);
            Patient patient = new Patient(id, firstName, lastName, medicalHistory, numOfAge);
            patients.Add(patient);
            Console.WriteLine("Patient was added successfully");
        }

        public void RemoveNurse()
        {
            DisplayAllNurses();
            if (nurses.Count > 0)
            {
                Console.Write("Which number? ");
                var deletion = Console.ReadLine();
                if (nurses.Count() > 0) { }
                if (int.TryParse(deletion, out int deletedNum) && deletedNum > 0 && deletedNum <= nurses.Count())
                {
                    nurses.Remove(nurses[deletedNum - 1]);
                    Console.WriteLine("Patient was removed successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else { Console.WriteLine("NO NURSE."); }
        }
        public void DisplayAllNurses()
        {
            for (int i = 0; i < nurses.Count; i++)
            {
                Console.Write($"{i + 1}."); nurses[i].DisplayInfo();
            }
        }
        public void AddNurse()
        {
            Console.WriteLine("Add New Nurse:");
            Console.Write("ID: ");
            var id = Console.ReadLine();
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Department: ");
            var department = Console.ReadLine();
            Console.Write("Experience: ");
            var experience = Console.ReadLine();
            int year;
            int.TryParse(experience, out year);
            Nurse nurse = new Nurse(id, firstName, lastName, department, year);
            nurses.Add(nurse);
            Console.WriteLine("Nurse was added successfully");
        }
        public void RemoveDoctor()
        {
            DisplayAllDoctors();
            if (doctors.Count > 0)
            {
                Console.Write("Which number? ");
                var deletion = Console.ReadLine();
                if (doctors.Count() > 0) { }
                if (int.TryParse(deletion, out int deletedNum) && deletedNum > 0 && deletedNum <= doctors.Count())
                {
                    doctors.Remove(doctors[deletedNum - 1]);
                    Console.WriteLine("Doctor was removed successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else { Console.WriteLine("NO DOCTOR."); }
        }

        public void DisplayAllDoctors()
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.Write($"{i + 1}."); doctors[i].DisplayInfo();
            }
        }
        public void AddDoctor()
        {
            Console.WriteLine("Add New Doctor:");
            Console.Write("ID:");
            var id = Console.ReadLine();
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Specialty: ");
            var specialty = Console.ReadLine();
            Console.Write("Experience: ");
            var experience = Console.ReadLine();
            int.TryParse(experience, out int year);
            Doctor doctor = new Doctor(id, firstName, lastName, specialty, year);
            doctors.Add(doctor);
            Console.WriteLine("Doctor was added successfully");
        }
    }
}
