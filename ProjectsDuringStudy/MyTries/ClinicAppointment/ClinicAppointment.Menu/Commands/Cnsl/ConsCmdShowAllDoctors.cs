using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAllDoctors : IMenuCommand
    {
        public void Execute()
        {
            DoctorService _doctorService = new DoctorService();

            Console.WriteLine("Information about all doctors:");

            IEnumerable<Doctor> _doctors = _doctorService.GetAll();

            if (_doctors.Count() > 0)
            {
                foreach(Doctor doctor in _doctors)
                {
                    _doctorService.ShowInfo(doctor);
                }                
            }
            else
            {
                Console.WriteLine($"\nThere aren't any doctors");
            }
        }
    }
}
