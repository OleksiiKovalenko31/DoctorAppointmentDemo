using MyDoctorAppointment.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Domain;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using System.Runtime.CompilerServices;


namespace MyDoctorAppointment.Service.Realizaton
{

    public class DoctorRealiz
    {
        private readonly DoctorService _doctorService;
        private static StringBuilder streminfodocs;

        public DoctorRealiz()
        {

            _doctorService = new DoctorService();
            streminfodocs = new StringBuilder();

        }

        public static void ShowAllDoctors()
        {
            
            var doctors = new DoctorService().GetAll(); // Assuming you have a method to get all doctors


            foreach (var doc in doctors)
            {
                streminfodocs.AppendLine($"Doctor ID - {doc.Id}");
                streminfodocs.AppendLine($"Name - {doc.Name}");
                streminfodocs.AppendLine($"Surname - {doc.Surname}");
                streminfodocs.AppendLine($"Doctor typ - {doc.DoctorType}");
                streminfodocs.AppendLine($"Phone - {doc.Phone}");
                streminfodocs.AppendLine($"Email - {doc.Email}");
                Console.WriteLine("------------------------");

                Console.Write($"{streminfodocs}");
                streminfodocs.Clear(); // Clear the StringBuilder for the next doctor

            }
            Console.WriteLine("------------------------\n");
        }

        public void AddDoctorRealiz()
        {
            Console.WriteLine("Adding doctor: ");
            Console.Write("Enter Doctor Name:");
            string? name = Console.ReadLine();
            Console.Write("Enter Doctor Surname:");
            string? surname = Console.ReadLine();
            Console.Write("Enter Doctor Email:");
            string? email = Console.ReadLine();
            Console.Write("Enter Doctor Phone:");
            string? phone = Console.ReadLine();
            Console.WriteLine("Enter Doctor Type:\r\n  1 - Dentist,\r\n  2 - Dermatologist,\r\n  3 - FamilyDoctor,\r\n  4 - Paramedic");
            bool validType = Enum.TryParse<DoctorTypes>(Console.ReadLine(), out DoctorTypes doctorType);
            if (!validType)
            {
                Console.WriteLine("Invalid doctor type. Please enter a valid number (1-4).");
                return; // Exit the method if the input is invalid
            }
            Console.Write("Enter Doctor Experience (in years):");
            byte.TryParse(Console.ReadLine(), out byte experience);
            Console.Write("Enter Doctor Salary:");
            decimal.TryParse(Console.ReadLine(), out decimal salary);
            Doctor newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Email = email,
                Phone = phone,
                DoctorType = doctorType,
                Experience = experience,
                Salary = salary
            };
            _doctorService.Create(newDoctor); // Call the method to add a new doctor
            Console.WriteLine($"Doctor {name}  {surname} added successfully!");
        }

        public void DeleteDoctorRealiz()
        {
            ShowAllDoctors(); // Display all doctors before deletion
            Console.Write("Enter Doctor ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                bool isDeleted = _doctorService.Delete(doctorId);
                if (isDeleted)
                {
                    Console.WriteLine("Doctor deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Doctor not found or could not be deleted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        public void UpdateDoctorRealiz()
        {
            Console.Write("Enter Doctor ID to update: ");
            //StringBuilder streminfodocs = new StringBuilder();
            bool validId = int.TryParse(Console.ReadLine(), out int doctorId);
            if (!validId)
            {
                Console.WriteLine("Invalid ID.");
                return; // Exit the method if the input is invalid
            }
            else if (validId)
            {
                var existingDoctor = _doctorService.Get(doctorId);


                if (existingDoctor != null)
                {
                    streminfodocs.AppendLine($"Doctor typ - {existingDoctor.DoctorType}");
                    streminfodocs.AppendLine($"Name - {existingDoctor.Name}");
                    streminfodocs.AppendLine($"Surname - {existingDoctor.Surname}");
                    streminfodocs.AppendLine($"Doctor ID - {existingDoctor.Id}");
                    streminfodocs.AppendLine($"Phone - {existingDoctor.Phone}");
                    streminfodocs.AppendLine($"Email - {existingDoctor.Email}");
                    Console.WriteLine("------------------------");

                    Console.Write($"{streminfodocs}");
                    streminfodocs.Clear(); // Clear the StringBuilder for the next doctor


                    Console.Write("Enter new Name (leave empty to keep current): ");
                    string? name = Console.ReadLine();
                    Console.Write("Enter new Surname (leave empty to keep current): ");
                    string? surname = Console.ReadLine();
                    Console.WriteLine("Enter new Doctor Type (leave empty to keep current):\r\n  1 - Dentist,\r\n  2 - Dermatologist,\r\n  3 - FamilyDoctor,\r\n  4 - Paramedic");
                    bool validType = Enum.TryParse<DoctorTypes>(Console.ReadLine(), out DoctorTypes doctorType);
                    if (!validType)
                    {
                        Console.WriteLine("Invalid doctor type. Please enter a valid number (1-4).");
                        return; // Exit the method if the input is invalid
                    }
                    Console.Write("Enter new Experience (in years, leave empty to keep current): ");
                    byte.TryParse(Console.ReadLine(), out byte experience);
                    Console.Write("Enter new Salary (leave empty to keep current): ");
                    decimal.TryParse(Console.ReadLine(), out decimal salary);
                    existingDoctor.Name = string.IsNullOrEmpty(name) ? existingDoctor.Name : name;
                    existingDoctor.Surname = string.IsNullOrEmpty(surname) ? existingDoctor.Surname : surname;
                    existingDoctor.DoctorType = doctorType;
                    existingDoctor.Experience = experience;
                    existingDoctor.Salary = salary;
                    _doctorService.Update(doctorId, existingDoctor);
                }
                else
                {
                    Console.WriteLine("Doctor not found.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
                Console.ReadLine();
            }
        }
    }
}

