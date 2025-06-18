using DoctorAppointmentDemo.Domain;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointmentDoctor.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace MyDoctorAppointment.Service.Realizaton
{
    internal class PatientRealiz
    {
        private readonly PatientService _patientsService;
        private static StringBuilder stremInfoPats;

        public PatientRealiz()
        {

            _patientsService = new PatientService();
            stremInfoPats = new StringBuilder();

        }
        public void AddPatientRealiz()
        {
            // Default value, can be changed later if needed
            string? additionalInfo = "No additional info";
            IllnessTypes illnessType = IllnessTypes.Ambulance;

            Console.WriteLine("Adding patient: ");
            Console.Write("Enter Patient Name:");
            string? name = Console.ReadLine();

            Console.Write("Enter Patient Surname:");
            string? surname = Console.ReadLine();

            Console.Write("Enter Patient Phone:");
            string? phone = Console.ReadLine();

            Console.Write("Enter Patient Email:");
            string? email = Console.ReadLine();

            Console.Write("Enter Patient Additional Info (optional):");
            additionalInfo = Console.ReadLine();

            Console.WriteLine("Enter Patient Adress:");
            string? address = Console.ReadLine();

            Console.WriteLine("Enter Patient Illness Type (default is Ambulance):");
            Console.WriteLine("1 - EyeDisease,\r\n2 - Infection,\r\n3 - DentalDisease,\r\n4 - SkinDisease\r\n5 - Ambulance");
            bool isValidInput = int.TryParse(Console.ReadLine(), out int illnessChoice);
            if (isValidInput && Enum.IsDefined(typeof(IllnessTypes), illnessChoice))
            {
                illnessType = (IllnessTypes)illnessChoice;
            }
            else
            {
                Console.WriteLine("Invalid illness type. Defaulting to Ambulance.");
            }


            var patient = new Patient
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = email,
                AdditionalInfo = "No additional info",
                Address = address,
                IllnessType = illnessType,
            };
            _patientsService.Create(patient);
            Console.WriteLine($"Patient {name}  {surname} added successfully!");
        }

        public void ShowAllPatients()
        {
            var patients = _patientsService.GetAll();
            if (patients == null || !patients.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }
            foreach (var patient in patients)
            {
                stremInfoPats.AppendLine($"Patient ID - {patient.Id}");
                stremInfoPats.AppendLine($"Name - {patient.Name}");
                stremInfoPats.AppendLine($"Surname - {patient.Surname}");
                stremInfoPats.AppendLine($"Phone - {patient.Phone}");
                stremInfoPats.AppendLine($"Email - {patient.Email}");
                stremInfoPats.AppendLine($"Address - {patient.Address}");
                stremInfoPats.AppendLine($"Illness Type - {patient.IllnessType}");
                Console.WriteLine("------------------------");
                Console.Write($"{stremInfoPats}");
                stremInfoPats.Clear(); // Clear the StringBuilder for the next patient
            }
            Console.WriteLine("------------------------\n");
        }

        public void UpdatePatientRealiz()
        {
            Console.WriteLine("Updating patient: ");

            ShowAllPatients(); // Show all patients before updating
            Console.Write("Enter Patient ID:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var patient = _patientsService.Get(id);
                if (patient == null)
                {
                    Console.WriteLine($"Patient with ID {id} not found.");
                    return;
                }
                Console.Write("Enter New Patient Name (leave empty to keep current):");
                string? name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) patient.Name = name;
                Console.Write("Enter New Patient Surname (leave empty to keep current):");
                string? surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname)) patient.Surname = surname;
                Console.Write("Enter New Patient Phone (leave empty to keep current):");
                string? phone = Console.ReadLine();
                if (!string.IsNullOrEmpty(phone)) patient.Phone = phone;
                Console.Write("Enter New Patient Email (leave empty to keep current):");
                string? email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) patient.Email = email;
                Console.Write("Enter New Patient Address (leave empty to keep current):");
                string? address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address)) patient.Address = address;
                Console.WriteLine("Enter New Patient Illness Type (default is Ambulance):");
                Console.WriteLine("1 - EyeDisease,\r\n2 - Infection,\r\n3 - DentalDisease,\r\n4 - SkinDisease\r\n5 - Ambulance");
                bool isValidInput = int.TryParse(Console.ReadLine(), out int illnessChoice);
                if (isValidInput && Enum.IsDefined(typeof(IllnessTypes), illnessChoice))
                {
                    patient.IllnessType = (IllnessTypes)illnessChoice;
                }
                else
                {
                    patient.IllnessType = IllnessTypes.Ambulance; // Default value
                    Console.WriteLine("Invalid illness type. Defaulting to Ambulance.");
                }
                _patientsService.Update(id, patient);
                Console.WriteLine($"Patient {name}  {surname} updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        public void DeletePatientRealiz()
        {
            Console.WriteLine("Deleting patient: ");
            ShowAllPatients(); // Show all patients before deletion
            Console.Write("Enter Patient ID to delete:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                string? name = _patientsService.Get(id)?.Name;
                string? surname = _patientsService.Get(id)?.Surname;
                bool isDeleted = _patientsService.Delete(id);

                if (isDeleted)
                {
                    Console.WriteLine($"Patient {name} {surname} deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Patient not found or could not be deleted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
    }
}
