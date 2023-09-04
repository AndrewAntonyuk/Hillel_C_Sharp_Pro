using System.ComponentModel;

namespace ClinicAppointment.Domain.Enums
{
    public enum DoctorTypes
    {
        [Description("Dentist can resolve problem with teethes")]
        Dentist = 1,

        [Description("Dermatologist can resolve problem with skin")]
        Dermatologist,

        [Description("Family doctor can direct you to certain doctor")]
        FamilyDoctor,

        [Description("Paramedic can give you emergency help")]
        Paramedic,

        [Description("Eye doctor can resolve problem with eyes")]
        EyeDoctor
    }
}
