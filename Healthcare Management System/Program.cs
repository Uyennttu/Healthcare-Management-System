using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Healthcare_Management_System
{    class Program
    {       
        public const int ADD_PATIENT = 1;
        public const int ADD_NURSE = 2;
        public const int ADD_DOCTOR = 3;
        public const int SCHEDULE_APPOINTMENT = 4;
        public const int DISPLAY_ALL_PATIENTS = 5;
        public const int DISPLAY_ALL_NURSES = 6;
        public const int DISPLAY_ALL_DOCTORS = 7;
        public const int DISPLAY_ALL_APPOINTMENTS = 8;
        public const int REMOVE_PATIENT = 9;
        public const int REMOVE_NURSE = 10;
        public const int REMOVE_DOCTOR = 11;
        public const int CANCEL_APPOINTMENT = 12;
        public const int SEARCH = 13;

        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            int selectedService;
            bool running = true;
            while (running)
            {
                Console.Clear();
                ShowMenu();

                Console.Write("Choose a service: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out selectedService))
                {
                    switch (selectedService)
                    {
                        case ADD_PATIENT:
                            {
                                hospital.AddPatient();
                                break;
                            }
                        case ADD_NURSE:
                            {
                                hospital.AddNurse();
                                break;
                            }
                        case ADD_DOCTOR:
                            {
                                hospital.AddDoctor();
                                break;
                            }
                        case SCHEDULE_APPOINTMENT:
                            {
                                hospital.ScheduleAppointment();
                                break;
                            }
                        case DISPLAY_ALL_PATIENTS:
                            {
                                hospital.DisplayAllPatients();
                                break;
                            }
                        case DISPLAY_ALL_NURSES:
                            {
                                hospital.DisplayAllNurses();
                                break;
                            }
                        case DISPLAY_ALL_DOCTORS:
                            {
                                hospital.DisplayAllDoctors();
                                break;
                            }
                        case DISPLAY_ALL_APPOINTMENTS:
                            {
                                hospital.DisplayAllAppointments();
                                break;
                            }
                        case REMOVE_PATIENT:
                            {
                                hospital.RemovePatient();
                                break;
                            }
                        case REMOVE_NURSE:
                            {
                                hospital.RemoveNurse();
                                break;
                            }
                        case REMOVE_DOCTOR:
                            {
                                hospital.RemoveDoctor();
                                break;
                            }
                        case CANCEL_APPOINTMENT:
                            {
                                hospital.CancelAppointment();
                                break;
                            }
                        case SEARCH:
                            {
                                SearchMenu(hospital);
                                break;

                            }
                        default:
                            Console.WriteLine("Thank you for using our service! Press any key to exit.");
                            Console.ReadKey();
                            return;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ReadKey();
                }               
            }
        }
        public static void SearchMenu(Hospital hospital)
        {
            Console.WriteLine("1. Search Patient by Name or ID: ");
            Console.WriteLine("2. Search Doctor by Name or ID or Specialty: ");
            Console.WriteLine("3. Search Appointment by PatientId or DoctorId or Date: ");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();
            if (int.TryParse(option, out int selectedOption))
            {
                Console.Write("Enter search query: ");
                string query = Console.ReadLine();
                switch (selectedOption)
                {
                    case 1:
                        {
                            hospital.SearchPatient(query);
                            break;
                        }
                    case 2:
                        {
                            hospital.SearchDoctor(query);
                            break;
                        }
                    case 3:
                        {
                            hospital.SearchAppointment(query);
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid input. Please enter one of these options.");
                        return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            
        }
        public static void ShowMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Healthcare Management System");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Add Nurse");
            Console.WriteLine("3. Add Doctor");
            Console.WriteLine("4. Schedule Appointment");
            Console.WriteLine("5. Display All Patients");
            Console.WriteLine("6. Display All Nurses");
            Console.WriteLine("7. Display All Doctors");
            Console.WriteLine("8. Display All Appointments");
            Console.WriteLine("9. Remove Patient");
            Console.WriteLine("10. Remove Nurse");
            Console.WriteLine("11. Remove Doctor");
            Console.WriteLine("12. Cancel Appointment");
            Console.WriteLine("13. Search");
            Console.WriteLine("14. Exit");
            Console.WriteLine("---------------------------");            
        }
    }
}