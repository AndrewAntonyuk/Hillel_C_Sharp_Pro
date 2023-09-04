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
            Console.WriteLine("Information about all patients:");
            ConsWorkWithObjects.ShowAllObjects<IPatientService, Patient>(new PatientService());
        }
    }
}
