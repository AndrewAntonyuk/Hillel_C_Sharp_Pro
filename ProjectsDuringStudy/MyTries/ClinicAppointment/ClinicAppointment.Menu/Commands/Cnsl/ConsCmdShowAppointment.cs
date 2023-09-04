using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAppointment : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Please, enter id of appointment for showing details:");
            ConsWorkWithObjects.ShowObjectById<IAppointmentService, Appointment>(new AppointmentService());
        }
    }
}
