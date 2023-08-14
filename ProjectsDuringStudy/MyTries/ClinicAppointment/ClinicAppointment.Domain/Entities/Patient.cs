using ClinicAppointment.Domain.Enums;

namespace ClinicAppointment.Domain.Entities
{
    public  class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }

        public string? AddittionalInfo { get; set; }

        public string? Address { get; set; }
    }
}
