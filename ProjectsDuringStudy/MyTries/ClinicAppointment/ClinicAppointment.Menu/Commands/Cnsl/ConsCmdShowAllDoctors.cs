using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAllDoctors : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Information about all doctors:");
            ConsWorkWithObjects.ShowAllObjects<IDoctorService, Doctor>(new DoctorService());
        }
    }
}
