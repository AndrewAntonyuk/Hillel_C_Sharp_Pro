using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Utils;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Menu.Commands.Cnsl;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment
{

    public class ClinicAppointment
    {
        private readonly IMenuCommand _createDoctor;
        private readonly IMenuCommand _createPatient;
        private readonly IMenuCommand _createAppointment;
        private readonly IMenuCommand _deleteAppointment;
        private readonly IMenuCommand _deleteDoctor;
        private readonly IMenuCommand _deletePatient;
        private readonly IMenuCommand _exitFromApp;
        private readonly IMenuCommand _showAllAppointments;
        private readonly IMenuCommand _showAllDoctors;
        private readonly IMenuCommand _showAllPatients;
        private readonly IMenuCommand _showAppointment;
        private readonly IMenuCommand _showAppointmentsByDoctor;
        private readonly IMenuCommand _showAppointmentsByPatient;
        private readonly IMenuCommand _showDoctor;
        private readonly IMenuCommand _showPatient;
        private readonly IMenuCommand _showHelp;
        private readonly IMenuCommand _updateAppointment;
        private readonly IMenuCommand _updateDoctor;
        private readonly IMenuCommand _updatePatient;
        private readonly IGeneralValidator<MenuTypes> _validatorCmd;

        public ClinicAppointment()
        {
            _createDoctor = new ConsCmdCreateDoctor();
            _createPatient = new ConsCmdCreatePatient();
            _createAppointment = new ConsCmdCreateAppointment();
            _deleteAppointment = new ConsCmdDeleteAppointment();
            _deleteDoctor = new ConsCmdDeleteDoctor();
            _deletePatient = new ConsCmdDeletePatient();
            _exitFromApp = new ConsCmdExitFromApp();
            _showAllAppointments = new ConsCmdShowAllAppointments();
            _showAllDoctors = new ConsCmdShowAllDoctors();
            _showAllPatients = new ConsCmdShowAllPatients();
            _showAppointment = new ConsCmdShowAppointment();
            _showAppointmentsByDoctor = new ConsCmdShowAppointmentsByDoctor();
            _showAppointmentsByPatient = new ConsCmdShowAppointmentsByPatient();
            _showDoctor = new ConsCmdShowDoctor();
            _showPatient = new ConsCmdShowPatient();
            _showHelp = new ConsCmdShowHelp();
            _updateAppointment = new ConsCmdUpdateAppointment();
            _updateDoctor = new ConsCmdUpdateDoctor();
            _updatePatient = new ConsCmdUpdatePatient();
            _validatorCmd = new GeneralValidatorEnum<MenuTypes>();
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

                    switch (currentMenuChoice)
                    {
                        case MenuTypes.ExitFromApp: _exitFromApp.Execute(); break;
                        case MenuTypes.Help: _showHelp.Execute(); break;
                        case MenuTypes.CreateDoctor: _createDoctor.Execute(); break;
                        case MenuTypes.DeleteDoctor: _deleteDoctor.Execute(); break;
                        case MenuTypes.CreatePatient: _createPatient.Execute(); break;
                        case MenuTypes.DeletePatient: _deletePatient.Execute(); break;
                        case MenuTypes.ShowAllDoctors: _showAllDoctors.Execute(); break;
                        case MenuTypes.ShowAllPatients: _showAllPatients.Execute(); break;
                        case MenuTypes.ShowDoctor: _showDoctor.Execute(); break;
                        case MenuTypes.ShowPatient: _showPatient.Execute(); break;
                        case MenuTypes.UpdateDoctor: _updateDoctor.Execute(); break;
                        case MenuTypes.UpdatePatient: _updatePatient.Execute(); break;
                        case MenuTypes.CreateAppointment: _createAppointment.Execute(); break;
                        case MenuTypes.DeleteAppointment: _deleteAppointment.Execute(); break;
                        case MenuTypes.ShowAppointment: _showAppointment.Execute(); break;
                        case MenuTypes.UpdateAppointment: _updateAppointment.Execute(); break;
                        case MenuTypes.ShowAllAppointments: _showAllAppointments.Execute(); break;
                        case MenuTypes.ShowAppointmentsByDoctor: _showAppointmentsByDoctor.Execute(); break;
                        case MenuTypes.ShowAppointmentsByPatient: _showAppointmentsByPatient.Execute(); break;
                    }

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

            //Doctor doctor = new Doctor()
            //{
            //    Name = "TestName",
            //    Surname = "TestSurname",
            //    Salary = new decimal(2000.0),
            //    DoctorType = DoctorTypes.Dentist
            //};

            //FileUtils.WriteToXmlFile("C:\\DataTest\\TestXML.xml", doctor);

            //Doctor doctor2 = FileUtils.ReadFromXmlFile<Doctor>("C:\\DataTest\\TestXML.xml");

            //new DoctorService().ShowInfo(doctor2);

        }
    }
}


