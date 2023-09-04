using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAllAppointments : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Information about all appointments:");
            ConsWorkWithObjects.ShowAllObjects<IAppointmentService, Appointment>(new AppointmentService());
        }
    }
}
