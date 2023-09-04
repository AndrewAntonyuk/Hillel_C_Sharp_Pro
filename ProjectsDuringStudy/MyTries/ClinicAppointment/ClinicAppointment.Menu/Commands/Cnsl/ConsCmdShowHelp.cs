using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Extentions;
using ClinicAppointment.Menu.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowHelp : IMenuCommand
    {
        public void Execute()
        {
            Console.WriteLine("The next commands available:");
            EnumExtension.ShowEnumDescription(MenuTypes.ExitFromApp);
        }
    }
}
