using System.ComponentModel;

namespace ClinicAppointment.Domain.Enums
{
    public enum IllnessTypes
    {
        [Description("Problem with eyes")]
        EyeDisease = 1,

        [Description("Problem with caught a cold or fever or something like that")]
        Infection,

        [Description("Problem with teeth")]
        DentalDisease,

        [Description("Problem with skin")]
        SkinDisease,

        [Description("Problem with parts of body")]
        Ambulance,
    }
}
