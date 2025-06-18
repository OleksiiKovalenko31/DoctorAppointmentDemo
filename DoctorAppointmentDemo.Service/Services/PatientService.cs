using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;


namespace MyDoctorAppointmentDoctor.Service.Services
{
    internal class PatientService : IPatientService
    {
        private readonly PatientRepository _PatientRepository;

        public PatientService()
        {
            _PatientRepository = new PatientRepository();
        }

        public Patient Create(Patient Patient)
        {
            return _PatientRepository.Create(Patient);
        }

        public bool Delete(int id)
        {
            return _PatientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _PatientRepository.GetById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _PatientRepository.GetAll();
        }

        public Patient Update(int id, Patient Patient)
        {
            return _PatientRepository.Update(id, Patient);
        }

    }
}
