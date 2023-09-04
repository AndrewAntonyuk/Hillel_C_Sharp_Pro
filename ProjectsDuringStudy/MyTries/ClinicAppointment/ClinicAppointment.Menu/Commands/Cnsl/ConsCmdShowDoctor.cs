using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowDoctor : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Please, enter id of doctor for showing details:");
            ConsWorkWithObjects.ShowObjectById<IDoctorService, Doctor>(new DoctorService());
        }
    }
}
