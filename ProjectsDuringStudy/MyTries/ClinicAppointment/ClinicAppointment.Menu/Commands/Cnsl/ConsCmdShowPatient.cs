using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowPatient : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Please, enter id of patient for showing details:");
            ConsWorkWithObjects.ShowObjectById<IPatientService, Patient>(new PatientService());
        }
    }
}
