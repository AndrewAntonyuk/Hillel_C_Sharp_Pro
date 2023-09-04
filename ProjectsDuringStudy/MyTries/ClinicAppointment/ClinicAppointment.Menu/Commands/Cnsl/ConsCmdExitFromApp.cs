using ClinicAppointment.Menu.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdExitFromApp : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("Goodbye and good luck!");
        }
    }
}
