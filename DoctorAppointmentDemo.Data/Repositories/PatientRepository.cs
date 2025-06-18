using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;


namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            //    var patientType = Enum.GetName(typeof(Patients), patient.Id)/*(Domain.Enums.DoctorTypes, doctor.DoctorType)*/;

            //    Console.WriteLine($"Doctor Information: ");
            //    Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Specialization: {patientType}, CreatedAt: {patient.CreatedAt}, UpdatedAt: {patient.UpdatedAt}");
        }


        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;


            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}

