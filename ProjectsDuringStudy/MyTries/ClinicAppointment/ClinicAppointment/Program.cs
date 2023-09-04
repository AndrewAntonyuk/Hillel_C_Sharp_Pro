using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Menu.Commands.Cnsl;
using ClinicAppointment.Menu.Interfaces;

namespace ClinicAppointment
{

    public class ClinicAppointment
    {
        private readonly IGeneralValidator<MenuTypes> _validatorCmd;
        private Dictionary<MenuTypes, IMenuCommand> _commands;

        public ClinicAppointment()
        {
            _commands = new Dictionary<MenuTypes, IMenuCommand>();
            _validatorCmd = new GeneralValidatorEnum<MenuTypes>();

            _commands.Add(MenuTypes.Help, new ConsCmdShowHelp());
            _commands.Add(MenuTypes.CreateDoctor, new ConsCmdCreateDoctor());
            _commands.Add(MenuTypes.CreatePatient, new ConsCmdCreatePatient());
            _commands.Add(MenuTypes.CreateAppointment, new ConsCmdCreateAppointment());
            _commands.Add(MenuTypes.DeleteAppointment, new ConsCmdDeleteAppointment());
            _commands.Add(MenuTypes.DeleteDoctor, new ConsCmdDeleteDoctor());
            _commands.Add(MenuTypes.DeletePatient, new ConsCmdDeletePatient());
            _commands.Add(MenuTypes.ExitFromApp, new ConsCmdExitFromApp());
            _commands.Add(MenuTypes.ShowAllAppointments, new ConsCmdShowAllAppointments());
            _commands.Add(MenuTypes.ShowAllDoctors, new ConsCmdShowAllDoctors());
            _commands.Add(MenuTypes.ShowAllPatients, new ConsCmdShowAllPatients());
            _commands.Add(MenuTypes.ShowAppointment, new ConsCmdShowAppointment());
            _commands.Add(MenuTypes.ShowAppointmentsByDoctor, new ConsCmdShowAppointmentsByDoctor());
            _commands.Add(MenuTypes.ShowAppointmentsByPatient, new ConsCmdShowAppointmentsByPatient());
            _commands.Add(MenuTypes.ShowDoctor, new ConsCmdShowDoctor());
            _commands.Add(MenuTypes.ShowPatient, new ConsCmdShowPatient());
            _commands.Add(MenuTypes.UpdateAppointment, new ConsCmdUpdateAppointment());
            _commands.Add(MenuTypes.UpdateDoctor, new ConsCmdUpdateDoctor());
            _commands.Add(MenuTypes.UpdatePatient, new ConsCmdUpdatePatient());
        }

        public void Menu()
        {
            MenuTypes currentMenuChoice = 0;

            Console.WriteLine("Welcome to our app!!!");

            while (currentMenuChoice != MenuTypes.ExitFromApp)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Please enter id of command (for help type 1)");
                try
                {
                    currentMenuChoice = _validatorCmd.Validate(Console.ReadLine());

                    IMenuCommand? currentCmd = _commands.GetValueOrDefault(currentMenuChoice);

                    if (currentCmd != null)
                        currentCmd.Execute();
                    else
                        Console.WriteLine($"Cant find appropriate action for {currentMenuChoice}");

                    Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }

    public static class Program
    {
        public static void Main()
        {
            var clinicAppointment = new ClinicAppointment();

            clinicAppointment.Menu();
        }
    }
}


