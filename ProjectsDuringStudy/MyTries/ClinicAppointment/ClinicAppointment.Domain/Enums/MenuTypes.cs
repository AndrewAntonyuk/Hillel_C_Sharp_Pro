using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ClinicAppointment.Domain.Enums
{
    public enum MenuTypes
    {
        [Description("Show help about functions")]
        Help = 1,
        [Description("Create new doctor")]
        CreateDoctor,
        [Description("Get all available doctors")]
        ShowAllDoctors,
        [Description("Get doctor by Id")]
        ShowDoctor,
        [Description("Delete doctor by Id")]
        DeleteDoctor,
        [Description("Update doctor by Id")]
        UpdateDoctor,
        [Description("Create new patient")]
        CreatePatient,
        [Description("Get all patients in system")]
        ShowAllPatients,
        [Description("Get patient by Id")]
        ShowPatient,
        [Description("Delete patient by Id")]
        DeletePatient,
        [Description("Update patient by Id")]
        UpdatePatient,
        [Description("Create new appointment")]
        CreateAppointment,
        [Description("Get all appointments in system")]
        ShowAllAppointments,
        [Description("Get appointment by Id")]
        ShowAppointment,
        [Description("Delete appointment by Id")]
        DeleteAppointment,
        [Description("Update appointment by Id")]
        UpdateAppointment,
        [Description("Get all appointments by doctor")]
        ShowAppointmentsByDoctor,
        [Description("Get all appointments by patient")]
        ShowAppointmentsByPatient,
        [Description("Exit from application")]
        ExitFromApp
    }  
}
