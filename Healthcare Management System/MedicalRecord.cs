using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_Management_System
{
    public class MedicalRecord
    {
        public string RecordId;
        public Appointment Appointment;
        public string Diagnosis;
        public string Treatment;
        public string MedicalHistory;

        public MedicalRecord(string recordId, Appointment appointment, string diagnosis, string treatment, string medicalHistory)
        {
            RecordId = recordId;
            Appointment = appointment;
            Diagnosis = diagnosis;
            Treatment = treatment;
            MedicalHistory = medicalHistory;
        }

        public void DisplayMedicalRecord()
        {
            Console.WriteLine($"Record ID: {RecordId,-5}" +
                $"Doctor: {Appointment.Doctor.FirstName} {Appointment.Doctor.LastName,-7}" +
                $"Patient: {Appointment.Patient.FirstName} {Appointment.Patient.LastName,-7}" +
                $"Medical History: {MedicalHistory,-7}" +
                $"Diagnosis: {Diagnosis, -7}" +
                $"Treatment: {Treatment}");
        }
    }
}
