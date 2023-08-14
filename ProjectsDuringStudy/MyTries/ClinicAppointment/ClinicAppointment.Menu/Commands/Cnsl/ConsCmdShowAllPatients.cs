using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAllPatients : IMenuCommand
    {
        public void Execute()
        {
            IPatientService _patientService = new PatientService();

            Console.WriteLine("Information about all patients:");

            IEnumerable<Patient> _patients = _patientService.GetAll();

            if (_patients.Count() > 0)
            {
                foreach (Patient patient in _patients)
                {
                    _patientService.ShowInfo(patient);
                }
            }
            else
            {
                Console.WriteLine($"\nThere aren't any patients");
            }
        }
    }
}
