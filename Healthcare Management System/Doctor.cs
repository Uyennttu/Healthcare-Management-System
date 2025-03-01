﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_Management_System
{
    public class Doctor : Person
    {
        
        public string Specialty;
        public int Experience;
        public Doctor(string id, string firstName, string lastName, string specialty, int experience) : base(id, firstName, lastName)
        {
            Specialty = specialty;
            Experience = experience;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id,-5} " +
                    $"Name: {FirstName} {LastName, -7} " +
                    $"Specialty: {Specialty,-15} " +
                    $"Experience: {Experience} years");
        }
                 

        

    }
    
    }

