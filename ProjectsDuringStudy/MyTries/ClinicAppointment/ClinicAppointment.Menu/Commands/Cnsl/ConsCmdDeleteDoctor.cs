using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdDeleteDoctor : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Please, enter id of doctor for delete:");
            ConsWorkWithObjects.DeleteObjectById<IDoctorService, Doctor>(new DoctorService());
        }
    }
}
