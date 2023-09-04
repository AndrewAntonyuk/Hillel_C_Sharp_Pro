using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdDeletePatient : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Please, enter id of patient for delete:");
            ConsWorkWithObjects.DeleteObjectById<IPatientService, Patient>(new PatientService());
        }
    }
}
