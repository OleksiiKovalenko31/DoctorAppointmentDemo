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
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Service.Realizaton;






namespace DoctorAppointmentDemo.Service.Services
{

    public class Menu
    {
        private readonly DoctorRealiz _doctorRealiz;
        public Menu()
        {
            _doctorRealiz = new ();

        }


        public static void ShowMenu()
        {
            while (true)
            {
                StartMenu();

                bool inout = int.TryParse(Console.ReadLine(), out int chose);
                if (!inout) { chose = -1; }

                if (chose == 1)
                {
                    Console.WriteLine("You chose Doctors");
                    ShowDoctorsMenu(); // Call the method to show the Doctors menu
                }
                else if (chose == 2)
                {
                    Console.WriteLine("You chose Patients");
                    ShowPatientsMenu(); // Call the method to show the Patients menu
                }
                else if (chose == 3)
                {
                    Console.WriteLine("You chose Appointments");
                    ShowAppointmentsMenu(); // Call the method to show the Appointments menu
                }
                else if (chose == 0)
                {
                    Console.Write("Exit ?: 1 - Yes / 2 - No ");
                    int.TryParse(Console.ReadLine(), out int exit);

                    if (exit == 1)

                    { break; }

                    else if (exit == 2)

                    { continue; }

                    else { Console.WriteLine("Incorrect format"); Console.ReadLine(); }
                }
                else 
                { 
                    Console.WriteLine("Incorrect choose");
                    Console.ReadLine();
                  
                }

                          

            }

        }
        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Doctor Appointment System!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine();
            Console.WriteLine("1 Doctors\n2 Patients\n3 Appoitments\n0 Exit\n");
            
           
        }

        public  static void ShowDoctorsMenu()
        {
            DoctorRealiz realiz = new DoctorRealiz (); // Assuming you have a class to handle doctor operations

            Console.Clear();
            Console.WriteLine("Welcome to Doctors Menu!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine();
            Console.WriteLine("1 - Add Doctor\n2 - View All Doctors\n3 - Update Doctor\n4 - Delete Doctor\n0 - Exit to previous menu\n");
            bool inout = int.TryParse(Console.ReadLine(), out int chose);
            if (!inout) { chose = -1; }

            if (chose == 1)
            { while (true)
                {
                    Console.WriteLine("You chose to Add Doctor\n");
                    realiz.AddDoctorRealiz(); // Call the method to add a new doctor
           
                    Console.WriteLine("Add new doctor?:  1 - No / 2 - Yes");

                    int.TryParse((Console.ReadLine()), out int exit);

                    if (exit == 1)

                    { /*break*/ ShowDoctorsMenu(); }

                    else if (exit == 2)

                    { continue; }

                    else 
                    { 
                        Console.WriteLine("Incorrect format"); 
                        Console.ReadLine();
                        ShowDoctorsMenu(); 
                    }
                }


            }
            else if (chose == 2)
            { 
                Console.WriteLine("You chose to View All Doctors\n");
               
               DoctorRealiz.ShowAllDoctors(); // Call the method to show all doctors
               
                Console.ReadLine();
            }
            else if (chose == 3)
            {
                Console.WriteLine("You chose to Update Doctor");

                realiz.UpdateDoctorRealiz(); // Call the method to update a doctor
                //    int.TryParse(Console.ReadLine(), out int id);
                //    var docinf = service.Get(12);
                //    Console.WriteLine($"Name - {docinf.Name}\nSurname - {docinf.Surname}\nDoctor typ - {Enum.GetName(typeof(DoctorTypes), docinf.DoctorType)}\nDoctorID - {docinf.Id}");
            }
            else if (chose == 4)
            {

                Console.WriteLine("You chose to Delete Doctor\n");

                DoctorRealiz.ShowAllDoctors(); // Call the method to show all doctors before deletion
                realiz.DeleteDoctorRealiz(); // Call the method to delete a doctor
                //Console.WriteLine("Enter Doctor ID to delete:");
                //int.TryParse(Console.ReadLine(), out int id);
                //service.Delete(id);
            }
            else if (chose == 0)
            {
                Console.WriteLine("Exit to previous menu");
                
                Console.ReadLine();
                StartMenu(); // Return to the main menu after exiting
            }
            else { Console.WriteLine("Incorrect choose"); Console.ReadLine(); }

             //Console.ReadLine(); // Wait for user input before returning to the menu
             //ShowDoctorsMenu(); // Return to the Doctors menu after any action
            
        }

        public static void ShowPatientsMenu()
        {
            PatientRealiz realiz = new PatientRealiz(); // Assuming you have a class to handle patient operations
            Console.Clear();
            Console.WriteLine("Welcome to Patients Menu!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine();
            Console.WriteLine("1 - Add Patient\n2 - View All Patients\n3 - Update Patient\n4 - Delete Patient\n0 - Exit to previous menu\n");
            bool inout = int.TryParse(Console.ReadLine(), out int chose);
            if (!inout) { chose = -1; }

            if (chose == 1)
            { 
                Console.WriteLine("You chose to Add Patient"); 
                realiz.AddPatientRealiz(); // Call the method to add a new patient

            }
            else if (chose == 2)
            { 
                Console.WriteLine("You chose to View All Patients"); 
                realiz.ShowAllPatients(); // Call the method to show all patients
            }
            else if (chose == 3)
            { 
                Console.WriteLine("You chose to Update Patient"); 
                realiz.UpdatePatientRealiz(); // Call the method to update a patient
            }
            else if (chose == 4)
            { 
                Console.WriteLine("You chose to Delete Patient"); 
                realiz.DeletePatientRealiz(); // Call the method to delete a patient
            }
            else if (chose == 0)
            {
                Console.WriteLine("Exit to previous menu");
                Console.ReadLine();
                StartMenu(); // Return to the main menu after exiting
            }
            else { Console.WriteLine("Incorrect choose"); }
            Console.ReadLine();
            ShowPatientsMenu(); // Return to the Patients menu after any action
        }

        public static void ShowAppointmentsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Appointments Menu!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine();
            Console.WriteLine("1 - Add Appointment\n2 - View All Appointments\n3 - Update Appointment\n4 - Delete Appointment\n0 - Exit to previous menu\n");
            bool inout = int.TryParse(Console.ReadLine(), out int chose);
            if (!inout) { chose = -1; }

            if (chose == 1)
            { Console.WriteLine("You chose to Add Appointment"); }
            else if (chose == 2)
            { Console.WriteLine("You chose to View All Appointments");}
            else if (chose == 3)
            { Console.WriteLine("You chose to Update Appointment"); }
            else if (chose == 4)
            { Console.WriteLine("You chose to Delete Appointment");}
            else if (chose == 0)
            {
                Console.WriteLine("Exit to previous menu");
                Console.ReadLine();
                StartMenu(); // Return to the main menu after exiting
            }
            else { Console.WriteLine("Incorrect choose"); }
            Console.ReadLine();
            ShowAppointmentsMenu(); // Return to the Appointments menu after any action
        }

        //public static void ShowAllDoctors()
        //{

        //    //var doctors = new DoctorService().GetAll(); // Assuming you have a method to get all doctors
        //    //foreach (var doc in doctors)
        //    //{
        //    //    Console.WriteLine($"Name - {doc.Name}\nSurname - {doc.Surname}\nDoctor typ - {doc.DoctorType}\nDoctor ID - {doc.Id}");
        //    //    Console.WriteLine();

        //    //}
        //    //Console.WriteLine("-------------------\n");
        //}

    }

}
