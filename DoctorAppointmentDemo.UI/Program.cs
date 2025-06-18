using DoctorAppointmentDemo.Service.Services;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;


namespace MyDoctorAppointment.Service.Services
{
    public class DoctorAppointment
    {

        // 1 - создать enum для меню и описать меню
        // 2 - реализовать отдельный класс для работы с меню(например, DoctorAppointmentMenu)
        // 3 - реализовать методы для работы с меню (добавление, удаление, обновление, получение всех врачей, пициентов и т.д.)       
        // 4 - реализовать отдельный класс для записи и чтения данных из файла (например, DoctorAppointmentFileService)

        //private readonly DoctorService _doctorService;

        //public DoctorAppointment()
        //{
        //    _doctorService = new DoctorService();
        //}

        //public void ReadFile()
        //{
        //    Console.WriteLine("Current doctors list: ");
        //    var docs = _doctorService.GetAll();// перемення для хранения списка врачей реализована в сервисе IDoctorService

        //    foreach (var doc in docs)
        //    {
        //        Console.WriteLine($"Name - {doc.Name}\nSurname - {doc.Surname}\nDoctor typ - {doc.DoctorType}");
        //        Console.WriteLine();

        //    }
        //    Console.WriteLine("-------------------");
        //    // Реализовать чтение из файла
        //    //return _doctorService; 
        //}

        //public void WriteFile()
        //{

        //    Console.WriteLine("Current doctors list: ");
        //    var docs = _doctorService.GetAll();// перемення для хранения списка врачей реализована в сервисе IDoctorService

        //    foreach (var doc in docs)
        //    {
        //        Console.WriteLine($"Name - {doc.Name}\nSurname - {doc.Surname}\nDoctor typ - {doc.DoctorType}");
        //        Console.WriteLine();

        //    }
        //    Console.WriteLine("-------------------");

        //    Console.WriteLine("Adding doctor: ");

        //    var newDoctor = new Doctor
        //    {
        //        Name = "Myroslav",
        //        Surname = "Zakopan",
        //        Experience = 20,
        //        DoctorType = Domain.Enums.DoctorTypes.FamilyDoctor,
        //    };

        //    _doctorService.Create(newDoctor);

        //    Console.WriteLine("Current doctors list: ");
        //    docs = _doctorService.GetAll();

        //    foreach (var doc in docs)
        //    {
        //        Console.WriteLine($"Name - {doc.Name}\nSurname - {doc.Surname}\nDoctor typ - {doc.DoctorType}");
        //        Console.WriteLine();

        //    }
        //    //Console.WriteLine($"Name - {docs.Name}\nSurname - {doc.Surname}\nDoctor typ - {doc.DoctorType}");
        //    Console.WriteLine("-------------------");
            
        //}


    }
   

    public static class Program
    {
        public static void Main()
        {
            Menu.ShowMenu(); // вызов метода из класса Menu, который реализует логику меню

            //var doctorAppointment = new DoctorAppointment();
            //doctorAppointment.WriteAndReadFile();
        }
    }
}