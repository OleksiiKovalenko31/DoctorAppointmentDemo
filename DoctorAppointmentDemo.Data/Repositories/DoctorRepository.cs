using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            var doctorType = Enum.GetName(typeof(DoctorTypes), doctor.Id)/*(Domain.Enums.DoctorTypes, doctor.DoctorType)*/;

            Console.WriteLine($"Doctor Information: ");
            Console.WriteLine($"Id: {doctor.Id}, Name: {doctor.Name}, Specialization: {doctorType}, CreatedAt: {doctor.CreatedAt}, UpdatedAt: {doctor.UpdatedAt}");
        }


        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;
            

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
