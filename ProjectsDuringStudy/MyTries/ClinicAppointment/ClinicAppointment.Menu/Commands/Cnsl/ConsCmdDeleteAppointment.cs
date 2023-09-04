using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdDeleteAppointment : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Please, enter id of appointment for delete:");
            ConsWorkWithObjects.DeleteObjectById<IAppointmentService, Appointment>(new AppointmentService());
        }
    }
}
